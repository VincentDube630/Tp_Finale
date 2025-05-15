using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Systeme
    {
        public static Dictionary<string, List<string>> dictionnaire { get; set; } = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> dictionnaire2 { get; set; }

        public static void ChargerDonnees()
        {
            string cheminFichier = "Donnees.csv";

            if (File.Exists(cheminFichier))
            {
                foreach (var ligne in File.ReadLines(cheminFichier))
                {
                    string[] donnees = ligne.Split(';');

                    if (donnees.Length >= 1)
                    {
                        var valeurs = new List<string>();
                        var listeObservateur = new List<string>(); // Liste qui va avec la clée du dictionnaire pour les observateurs
                        var listeScientifique = new List<string>(); // Liste pour les scientifiques
                        var listMission = new List<string>();
                        string cleValeur;

                        // Ajout des valeurs dans une liste générale
                        for (int i = 0; i < donnees.Length; i++)
                        {
                            valeurs.Add(donnees[i]);
                        }
                        // Si observateur
                        if (valeurs[3] == "")
                        {
                            cleValeur = donnees[0];
                            listeObservateur.Add(valeurs[1]); // Deviens le nom en 0
                            listeObservateur.Add(valeurs[2]); // Deviens date naissance en 1

                            // Ajouter au dictionnaire
                            Systeme.dictionnaire.Add(cleValeur, listeObservateur);

                        }
                        if (valeurs[5]!="")
                        {
                            cleValeur=valeurs[1];
                            listMission.Add(valeurs[0]); // Le nom de la mission devient 0
                            listMission.Add(valeurs[2]);//Le matricule du scientifique devient le numero 1
                            listMission.Add(valeurs[3]);//la catégorie devient le numero 2
                            listMission.Add(valeurs[4]);// le vaisseau devient le 3
                            listMission.Add(valeurs[5]);// la duree devient le 4
                            listMission.Add(valeurs[6]);// La date de lancement devient le 5
                            if (!Systeme.dictionnaire.ContainsKey(cleValeur))
                            {
                                Systeme.dictionnaire.Add(cleValeur, listMission);

                            }

                        }
                        // Si scientifique
                        if (valeurs[5] == "" && valeurs[3]!="") 
                        {
                            cleValeur = valeurs[3];
                            listeScientifique.Add(valeurs[1]); // Deviens le nom en 0
                            listeScientifique.Add(valeurs[2]); // Deviens date naissance en 1
                            listeScientifique.Add(valeurs[4]); // Deviens la fonction (ingénieur...) en 2

                            // Ajouter au dictionnaire

                            if (!Systeme.dictionnaire.ContainsKey(cleValeur))
                            {
                                Systeme.dictionnaire.Add(cleValeur, listeScientifique);
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Fichier introuvable");
            }
        }
        
        public void SauvegarderDonnees()
        {

        }

        public void ConnexionUtilisateur(string id)
        {
            if (dictionnaire.ContainsKey(id) == false)
            {
                Console.WriteLine("Aucune correspondance trouvé");
            }
            else
            {
                string observateur1 = "";
                List<string> valeurs = dictionnaire[id];
                string nomComplet = valeurs[0];
                string[] nomGauche = nomComplet.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string prenom = "";
                string nom = "";
                if (valeurs.Count < 2 && !string.IsNullOrWhiteSpace(valeurs[ 2]))
                {
                    observateur1 = "A";
                }
                if (nomGauche.Length >= 2)
                {
                    prenom = nomGauche[0];
                    nom = string.Join(" ", nomGauche.Skip(1)); // Si Nom de famille avec espace
                }
                if (valeurs.Count > 2 && !string.IsNullOrWhiteSpace(valeurs[2])&& observateur1=="A") // Si il y a des données a la valeur 3 du la liste a l'id donnée alors ce n'est pas un observateur mais un scientifique
                {
                    Console.WriteLine("Ce numéro n'est pas un observateur");
                }
                else if (valeurs.Count > 2 && !string.IsNullOrWhiteSpace(valeurs[2]) && observateur1 == "")
                {
                    Scientifique scientifique = new Scientifique(id, nom, prenom, DateTime.Parse(valeurs[1]), "sijdsji");
                    scientifique.AfficherInfo();
                }
                else
                {
                    Observateur observateur = new Observateur(id,nom, prenom, DateTime.Parse(valeurs[1]), "233 rue djdd");
                    observateur.AfficherInfo();
                    Console.WriteLine("Recherche d'une mission (RM) : ");
                    Console.WriteLine("Liste des missions (LM) : ");
                    Console.WriteLine("Recherche un scientifique (RS) : ");
                    Console.WriteLine("Liste des scientifiques (LS) : ");
                    Console.WriteLine("Liste des instruments de mesure (LI) : ");
                    string mo = "";
                    bool recommencer = true;
                    do
                    {
                        try
                        {
                            mo = Console.ReadLine();
                            recommencer = true;
                        }
                        catch (FormatException)
                        {
                            recommencer = false;
                            Console.WriteLine("Erreur, ce n'est pas une chaine de caractère");
                        }
                    } while (!recommencer);
                    switch (mo)
                    {
                        case "RM":
                            Console.WriteLine("Numéro de référence : ");
                            string numeroReference = "";
                            try
                            {
                                numeroReference=Console.ReadLine();
                            }
                            catch(FormatException)
                            {
                                Console.WriteLine("Ce n'est pas le bon format!");
                            }
                            if (dictionnaire.ContainsKey(numeroReference) == false)
                            {
                                Console.WriteLine("Il n'y a pas de numéro de mission correspodant");
                            }
                            else
                            {
                                List<string> valeurs1 = dictionnaire[numeroReference];
                                Mission mission = new Mission(numeroReference, valeurs1[0], DateTime.Parse(valeurs1[5]), int.Parse(valeurs1[4]), valeurs1[3], valeurs1[2]);
                                mission.AfficherInfo();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.Write("Revenir au menu princiaple : ");
                                string revenir = Console.ReadLine();
                                ConnexionUtilisateur(id);
                                
                            }
                            break;
                        case "LM":
                            if(dictionnaire.ContainsKey(*))
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}

       

