using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Scientifique:Utilisateur
    {
        public string Matricule { get; set; }

        public Scientifique(string matricule, string nom, string prenom, DateTime dateNaissance, string adresse) : base(nom, prenom, dateNaissance, adresse)
        {
            Matricule = matricule;
        }

        public void AjouterMission(Mission mission)
        {
            
        }
        public void SuprimmerMission(Mission mission)
        {

        }
        public void AjouterInstrument(Instrument instrument)
        {

        }
        public void AjouterObjetCeleste()
        {

        }
    }
}
