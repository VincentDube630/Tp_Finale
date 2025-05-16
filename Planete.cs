using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Planete: ObjetCeleste// Classe fille de ObjetCeleste
    {
        // Constructeur pour recevoir les attributs de la classe mère
        public Planete(string scientifique,string mission,string nomObjet, string dateDebut,double masse,double rayon) : base(scientifique, mission,nomObjet, dateDebut, masse,rayon) { }
        // Redéfinir la classe CalculerVitesseGravitationelle() et CalculerVitesseOrbitale() 
        public override void CalculerVitesseGravitationelle()
        {

        }
        public override void CalculerVitesseOrbitale()
        {

        }
    }
}
