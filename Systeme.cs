using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Systeme
    {
        public Dictionary<int, List<string>> dictionnaireUtilisateur {  get; set; }
        public Dictionary<string, List<string>> dictionnaireMission {  get; set; }

        public Dictionary<int,List<string>> ChargerDonnees()
        {
            int id = 0;
            string nom = "";
            dictionnaireUtilisateur = new Dictionary<int, List<string>>();
            string[] Ligne = File.ReadAllLines("Donnees.csv");
            
            foreach (var lignes in Ligne)
            {
                var ligness = lignes.Split(';');
                if (int.TryParse(ligness[0], out id))
                {
                    var donnees = new List<string>();

                    for (int i = 1; i < ligness.Length; i++)
                    {
                        donnees.Add(ligness[i]);
                    }

                    dictionnaireUtilisateur[id] = donnees;
                }
                else
                {
                    
                }
            }

            return dictionnaireUtilisateur;
        }

        public void SauvegarderDonnees()
        {
            
        }

        public void ConnexionUtilisateur(string id)
        {
            if (dictionnaireUtilisateur.ContainsKey(Convert.ToInt32(id)) == false)
            {
                Console.WriteLine("Il n'y a pas d'observateur qui possèdent ce numéro d'indentification.");
            }
            else
            {

            }
        }
        public void DemanderChoix()
        {
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine("                         Simulation des \n                         missions spatiales");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine();
            Console.WriteLine("Choissisez une option : ");
            Console.WriteLine("Observateur (O)");
            Console.WriteLine("Scientifique (S)");
            Console.WriteLine("Quitter (Q)");
            Console.WriteLine();
            string choix = Console.ReadLine();
            if (choix == "Q")
            {
                return;
            }
            if (choix == "O")
            {
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                Console.WriteLine("                         Simulation des \n                         missions spatiales");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                Console.WriteLine();
                Console.WriteLine("Option Observateur : ");
                Console.Write("Veuillez fournir le numéro d'identification ----> ");
                string id1 = Console.ReadLine();
                int id = Convert.ToInt32(id1);
                Observateur observateur = new Observateur(dictionnaireUtilisateur[id]);
            }
            if (choix == "S")
            {

            }
        }
    }
}
