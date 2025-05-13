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

        public Scientifique(string matricule, string nom, string prenom, DateTime dateNaissance, string adresse) : base(nom, prenom, dateNaissance, adresse)
        {
            Matricule = matricule;
        }

        public void AjouterMission(Mission mission)
        {
            Missions.Add(mission);
            Console.WriteLine($"La mission {mission} a bien été ajouté");
        }
        public void SuprimmerMission(Mission mission)
        {
            Missions.Remove(mission);
            Console.WriteLine($"la mission {mission} a bien été suprimmer");
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
