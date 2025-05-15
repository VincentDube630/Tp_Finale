using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Etoile:ObjetCeleste
    {
        public double Luminosite {  get; set; }
        public Etoile(string scientifique, string mission,string nomObjet, string dateDebut, double masse,double rayon,double luminosite ) : base(scientifique,mission,nomObjet, dateDebut, masse,rayon) { this.Luminosite = luminosite; }
        public override void CalculerVitesseGravitationelle()
        {
            Console.WriteLine("d");
        }
        public override void CalculerVitesseOrbitale()
        {

        }
    }
}
