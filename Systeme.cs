using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Systeme
    {
        public Dictionary<int, List<string>> dictionnaire {  get; set; }
        
        public Dictionary<int,List<string>> ChargerDonnees()
        {
            int id = 0;
            dictionnaire = new Dictionary<int, List<string>>();
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

                    dictionnaire[id] = donnees;
                }
                else
                {

                }
            }

            return dictionnaire;
        }

        public void SauvegarderDonnees()
        {
            
        }

        public void ConnexionUtilisateur(string id)
        {
            
        }
    }
}
