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
        public Etoile(string scientifique, string mission,string nomObjet, int masse, string dateDebut,double rayon,double luminosite,ObjetCeleste destination) : base(scientifique,mission,nomObjet, dateDebut, masse, "Etoile",rayon,destination) { this.Luminosite = luminosite; }
        public override void CalculerVitesseGravitationelle()
        {
            Console.WriteLine("d");
        }
        public override void CalculerVitesseOrbitale()
        {

        }
    }
}
