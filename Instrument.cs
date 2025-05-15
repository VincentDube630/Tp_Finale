using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Instrument
    {
        public string IdMission { get; set; }
        public string NomInstrument {  get; set; }
        public string Categorie {  get; set; }
        public Systeme Systemes { get; set; }

        public Instrument(string idMission, string nomInstrument,string Categorie) 
        {
            this.IdMission = idMission;
            this.NomInstrument = nomInstrument;
            this.Categorie = Categorie;
        }
    }
}
