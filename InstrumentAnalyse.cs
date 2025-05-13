using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class InstrumentAnalyse:Instrument
    {
        public string TypeSignale {  get; set; }
        public InstrumentAnalyse(string idInstruement, string nomInstrument, string typeSignale) : base(idInstruement, nomInstrument, "Analyse") { this.TypeSignale = typeSignale; }
    }
}
