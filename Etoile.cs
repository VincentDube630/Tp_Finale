using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Etoile:ObjetCeleste
    {

        public Etoile(string nomObjet, int masse, string type) : base(nomObjet, masse, "Etoile") { }
        public override void CalculerVitesseGravitationelle()
        {
            Console.WriteLine("d");
        }
        public override void CalculerVitesseOrbitale()
        {

        }
    }
}
