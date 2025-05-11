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
