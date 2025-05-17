using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal abstract class ObjetCeleste
    {
        public string NomObjet {  get; set; }
        public double Masse {  get; set; }
        public string Categorie {  get; set; }
        public string DateDebut {  get; set; }
        public double Rayon { get; set; }
        public Systeme systeme { get; set; }
        public string Scientifique {  get; set; }
        public string Mission {  get; set; }
        public ObjetCeleste Destination { get; set; }
        public ObjetCeleste(string scientifique,string mission,string nomObjet,string dateDebut,double masse, double rayon)
        {
            Scientifique = scientifique;
            Mission = mission;
            NomObjet = nomObjet;
            Masse = masse;
            DateDebut = dateDebut;
            Rayon = rayon;
        }
        public abstract void CalculerVitesseGravitationelle(double rayon,double masse1,double masse2);
        public abstract void CalculerVitesseOrbitale(double masse,double rayon);
    }
}
