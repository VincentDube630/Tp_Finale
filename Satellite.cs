using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Satellite:ObjetCeleste
    {
        public double Altitude {  get; set; }
        public double VitesseOrbital {  get; set; }
        public Satellite(string scientifique,string mission,string nomObjet, int masse, string type,string dateDebut,double rayon, double altitude,double vitesseOrbital) : base(scientifique,mission,nomObjet, dateDebut, masse, "Satelitte",rayon)
        {
            this.Altitude=altitude;
            this.VitesseOrbital=vitesseOrbital;
        }

        public override void CalculerVitesseGravitationelle()
        {
            
        }
        public override void CalculerVitesseOrbitale()
        {

        }
    }
}
