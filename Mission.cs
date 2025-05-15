using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Mission
    {
        public string referenceMission {  get; set; }
        public string NomMission { get; set; }
        public DateTime DateLancement { get; set; }
        public int DureeEstimee {  get; set; }
        public string VaisseauSpatial { get; set; }
        public string Categorie {  get; set; }
        public Scientifique scientifique { get; set; }
        public List<ObjetCeleste> ObjetsCelestes { get; set; }
        public List<Instrument> Instruments { get; set; }
        public Systeme systeme {  get; set; }
        public Mission(string referenceMission,string nomMission,DateTime dateLancement,int dureeEstimee,string vaisseauSpatial,string categorie)
        {
            this.referenceMission = referenceMission;
            this.NomMission = nomMission;
            this.DateLancement = dateLancement;
            this.DureeEstimee = dureeEstimee;
            this.VaisseauSpatial = vaisseauSpatial;
            this.Categorie = categorie;
        }
        public void AfficherInfo()
        {
            Console.WriteLine($"Nom mission : {NomMission}");
            Console.WriteLine($"Numéro de la mission : {referenceMission}");
            Console.WriteLine($"Catégorie : {Categorie}");
            Console.WriteLine($"Vaisseau spatial : {VaisseauSpatial}");
            Console.WriteLine($"Durée estimé : {DureeEstimee}");
            Console.WriteLine($"Date lancement : {DateLancement}");
        }
    }
}
