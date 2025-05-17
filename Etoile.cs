using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Etoile: ObjetCeleste// Classe fille de ObjetCeleste
    {
        // Déclaration de l'atribut
        public double Luminosite {  get; set; }
        // Constructeur
        public Etoile(string scientifique, string mission,string nomObjet, string dateDebut, double masse,double rayon,double luminosite ) : base(scientifique,mission,nomObjet, dateDebut, masse,rayon) { this.Luminosite = luminosite; }
        // Redéfinir la classe CalculerVitesseGravitationelle() et CalculerVitesseOrbitale() 

        public override void CalculerVitesseGravitationelle(double rayon, double masse1, double masse2)
        {

        }
        public override void CalculerVitesseOrbitale(double masse, double rayon)
        {

        }
    }
}
