using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class InstrumentAnalyse: Instrument// Classe fille de Instrument
    {
        // Déclaration de l'attribut
        public string TypeSignale {  get; set; }
        // Constructeur pour avoir les attributs de la classe mère
        public InstrumentAnalyse(string idInstruement, string nomInstrument, string typeSignale) : base(idInstruement, nomInstrument, "Analyse") { this.TypeSignale = typeSignale; }
        // Afficher les infos
        public void AfficherInfo()
        {
            Console.WriteLine($"Type de signale : {TypeSignale}");
        }
    }
}
