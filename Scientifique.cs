using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Scientifique:Utilisateur
    {
        public string Matricule { get; set; }
        public List<Mission> Missions { get; set; }

        public Scientifique(string matricule, string nom, string prenom, DateTime dateNaissance, string adresse,Systeme systeme,Mission mission) : base(nom, prenom, dateNaissance, adresse,systeme)
        {
            Matricule = matricule;
            Missions = new List<Mission>();
        }

        public void AjouterMission(Mission mission)
        {
            Missions.Add(mission);
        }
        public void SuprimmerMission(Mission mission)
        {
            Missions.Remove(mission);
        }
        public void AjouterInstrument(Instrument instrument)
        {
            
        }
        public void AjouterObjetCeleste()
        {

        }
        public void AjouterObservateur(Observateur observateur)
        {
             
        }
        public void AjouterScientifique(Scientifique scientifique )
        {
            
        }
        public override void AfficherInfo()
        {
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("Profil scientifique");
            Console.WriteLine($"Matricule : {Matricule}");
            base.AfficherInfo();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("Résumé profil ");
            Console.WriteLine($"Total des missions affectées : {Missions.Count}");
            Console.WriteLine($"Catégorie planète :  ");
            Console.WriteLine($"Catégorie Etoile : ");
            Console.WriteLine($"Catégorie Satelitte : ");
        }
    }
}
