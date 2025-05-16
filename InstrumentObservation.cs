using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class InstrumentObservation:Instrument// Classe fille de Instrument
    {
        // Déclarer les attributs
        public string ChampsVision {  get; set; }
        public int LongeurOnde { get; set; }
        // Constructeur pour avoir les attributs de la classe mère
        public InstrumentObservation(string idInstruement, string nomInstrument,string champsVision,int longueurOnde) : base(idInstruement, nomInstrument, "Observation") 
        {
            this.ChampsVision = champsVision;
            this.LongeurOnde = longueurOnde;
        }
        // Afficher les infos
        public void AfficherInfo()
        {
            Console.WriteLine($"Champs de vision : {ChampsVision}");
            Console.WriteLine($"Longueur d'onde : {LongeurOnde}");
        } 
    }
}
