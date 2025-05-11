using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Systeme
    {
        public Dictionary<int,List<string>> ChargerDonnees()
        {
            var dictionnaire = new Dictionary<int, List<string>>();
            string[] Ligne = File.ReadAllLines("Donnees.csv");
            int nombreLigne = Ligne.Length;
            int nombreColonne = Ligne[0].Split(';').Length;
            for (int i = 0; i < nombreLigne; i++)
            {
                for (int j = 0; j < nombreColonne; j++)
                {
                    
                }
            }

        }

        public void SauvegarderDonnees()
        {

        }

        public void ConnexionUtilisateur(string id)
        {
            
        }
    }
}
