using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Satellite:ObjetCeleste
    {
        public Satellite(string nomObjet, int masse, string type) : base(nomObjet, masse, "Satelitte") { }

        public override void CalculerVitesseGravitationelle()
        {
            
        }
        public override void CalculerVitesseOrbitale()
        {

        }
    }
}
