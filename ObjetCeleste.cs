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
        public Systeme systeme { get; set; }
        public ObjetCeleste(string nomObjet,double masse, string categorie)
        {
            NomObjet = nomObjet;
            Masse = masse;
            Categorie = categorie;
        }
        public abstract void CalculerVitesseGravitationelle();
        public abstract void CalculerVitesseOrbitale();
    }
}
