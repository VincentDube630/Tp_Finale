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
        Systeme systeme;

        public Scientifique(string matricule, string nom, string prenom, DateTime dateNaissance) : base(nom, prenom, dateNaissance)
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
            Console.WriteLine("L'instrument a bien été enregistrer");
            
        }
        public void AjouterObjetCeleste()
        {

        }
        public void AjouterObservateur(Observateur observateur)
        {
            Console.WriteLine("Ajout réussi de l'observateur!");
             Systeme systeme = new Systeme();
             systeme.SauvegarderDonnees();
        }
        public void AjouterScientifique(Scientifique scientifique )
        {
            Console.WriteLine("Ajout réussi du scientifique");
            Systeme systeme = new Systeme();
            systeme.SauvegarderDonnees();
        }
        public override void AfficherInfo()
        {
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("Profil scientifique");
            Console.WriteLine($"Matricule : {Matricule}");
            base.AfficherInfo();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("Résumé profil ");
            Console.WriteLine($"Total des missions affectées : ");
            Console.WriteLine($"Catégorie planète :");
            Console.WriteLine($"Catégorie Etoile : ");
            Console.WriteLine($"Catégorie Satelitte : ");
        }
    }
}
