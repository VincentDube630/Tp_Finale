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
        public Planete(string scientifique,string mission,string nomObjet, int masse,string dateDebut,double rayon) : base(scientifique, mission,nomObjet, dateDebut, masse, "Planete",rayon) { }
        public override void CalculerVitesseGravitationelle()
        {
            
        }
        public override void CalculerVitesseOrbitale()
        {

        }
    }
}
