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
        public string Destination { get; set; }
        public DateTime DateLancement { get; set; }
        public int dureeEstimee {  get; set; }
        public string VaisseauSpatial { get; set; }
        public string Categorie {  get; set; }
        public Scientifique scientifique { get; set; }

    }
}
