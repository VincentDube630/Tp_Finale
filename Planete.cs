using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Planete:ObjetCeleste
    {
        public Planete(string nomObjet, int masse, string type) : base(nomObjet, masse, "Planete") { }
        public override void CalculerVitesseGravitationelle()
        {
            Console.WriteLine("d");
        }
        public override void CalculerVitesseOrbitale()
        {

        }
    }
}
