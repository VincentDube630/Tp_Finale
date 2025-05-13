using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Systeme
    {
        public Dictionary<string, List<string>> dictionnaire {  get; set; }

        public Dictionary<string,List<string>> ChargerDonnees()
        {
            dictionnaire = new Dictionary<string, List<string>>();
            string cheminFichier = "Donnees.csv";
            

            if (File.Exists(cheminFichier))
            {
                string[] lignes = File.ReadAllLines(cheminFichier);

                foreach (string ligne in lignes)
                {
                    if (string.IsNullOrWhiteSpace(ligne))
                    {
                        continue;
                    }
                        

                    string[] ligness = ligne.Split(';');

                    if (ligness.Length >= 1)
                    {
                        string cle = ligness[0].Trim();
                        var valeurs = new List<string>();

                        for (int i = 1; i < ligness.Length; i++)
                        {
                            valeurs.Add(ligness[i].Trim());
                        }
                        dictionnaire[cle] = valeurs;
                    }
                }

            }
            else
            {
                Console.WriteLine("Fichier introuvable");
            }
            return dictionnaire;
        }
        public void SauvegarderDonnees()
        {

        }

        public void ConnexionUtilisateur(string id)
        {
            if (dictionnaire.ContainsKey(id) == false)
            {
                Console.WriteLine("Il n'y a pas d'observateur qui possèdent ce numéro d'indentification.");
            }
            else
            {
                List<string> valeurs = dictionnaire[id];
                string nomComplet = valeurs[0];
                string[] nomGauche = nomComplet.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string prenom = "";
                string nom = "";
                if (nomGauche.Length >= 2)
                {
                    prenom = nomGauche[0];
                    nom = string.Join(" ", nomGauche.Skip(1)); // Si Nom de famille avec espace
                }    
                if (!string.IsNullOrWhiteSpace(valeurs[2])) // Si il y a des données a la valeur 3 du la liste a l'id donnée alors ce n'est pas un observateur mais un scientifique
                {
                    Console.WriteLine("Ce numéro n'est pas un observateur");
                }
                else
                {

                    Observateur observateur = new Observateur(id,nom, prenom, DateTime.Parse(valeurs[1]), "233 rue djdd");
                    observateur.AfficherInfo();
                    string mo = observateur.Choix();
                }
            }
        }
    }
}

       

