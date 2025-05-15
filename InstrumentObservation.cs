using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class InstrumentObservation:Instrument
    {
        public string ChampsVision {  get; set; }
        public int LongeurOnde { get; set; }
        public InstrumentObservation(string idInstruement, string nomInstrument,string champsVision,int longueurOnde) : base(idInstruement, nomInstrument, "Observation") 
        {
            this.ChampsVision = champsVision;
            this.LongeurOnde = longueurOnde;
        }

        public void AfficherInfo()
        {
            Console.WriteLine($"Champs de vision : {ChampsVision}");
            Console.WriteLine($"Longueur d'onde : {LongeurOnde}");
        } 
    }
}
