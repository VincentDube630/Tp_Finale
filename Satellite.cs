using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Satellite: ObjetCeleste// Classe fille de ObjetCeleste
    {
        // Déclaration des attributs
        public double Altitude {  get; set; }
        public double VitesseOrbital {  get; set; }

        // Constructeur
        public Satellite(string scientifique,string mission,string nomObjet,  string dateDebut,double masse,double rayon, double altitude,double vitesseOrbital) : base(scientifique,mission,nomObjet, dateDebut, masse,rayon)
        {
            this.Altitude=altitude;
            this.VitesseOrbital=vitesseOrbital;
        }
        // Redéfinir la classe CalculerVitesseGravitationelle() et CalculerVitesseOrbitale() 

        public override void CalculerVitesseGravitationelle(double rayon, double masse1, double masse2)
        {
            
        }
        public override void CalculerVitesseOrbitale(double masse, double rayon)
        {

        }
    }
}
