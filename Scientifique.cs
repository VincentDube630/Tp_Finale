using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Scientifique:Utilisateur // Classe fille de l'utilisateur
    {

        // Déclarer des attributs propre à la classe scientifique
        public string Matricule { get; set; }
        public List<Mission> Missions { get; set; }
        Systeme systeme;

        // Constructeur pour recevoir les attributs de la classe mère et déclarer les nouveaux
        public Scientifique(string matricule, string nom, string prenom, DateTime dateNaissance) : base(nom, prenom, dateNaissance)
        {
            Matricule = matricule;
        }
        // Ajouter des missions
        public void AjouterMission(Mission mission)
        {
            Missions.Add(mission);
            Console.WriteLine($"La mission {mission} a bien été ajouté");
        }

        // Suprimmer les missions
        public void SuprimmerMission(Mission mission)
        {
            Missions.Remove(mission);
            Console.WriteLine($"la mission {mission} a bien été suprimmer");
        }

        // Ajouter les instruments
        public void AjouterInstrument(Instrument instrument)
        {
            Console.WriteLine("L'instrument a bien été enregistrer");
            
        }
        // Ajouter les objets célèstes
        public void AjouterObjetCeleste()
        {

        }

        // Ajouter des observateurs
        public void AjouterObservateur(Observateur observateur)
        {
            Console.WriteLine("Ajout réussi de l'observateur!");
        }

        // Ajouter des scientifiques
        public void AjouterScientifique(Scientifique scientifique )
        {
            Console.WriteLine("Ajout réussi du scientifique");
        }

        // Redéfinir la classe AfficherInfo() avec sesw changements
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
