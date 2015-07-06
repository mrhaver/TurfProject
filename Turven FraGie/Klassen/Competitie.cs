using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turven_FraGie.Klassen
{
    public class Competitie
    {
        private string code;
        private string niveau;
        private string poule;
        private string regio;

        public string Code
        {
            get { return code; }
        }

        public string Niveau
        {
            get { return niveau; }
        }

        public string Poule
        {
            get { return poule; }
        }

        public string Regio
        {
            get { return regio; }
        }

        public Competitie(string code, string niveau, string poule, string regio)
        {
            this.code = code;
            this.niveau = niveau;
            this.poule = poule;
            this.regio = regio;
        }

        public override string ToString()
        {
            return "Competitiecode: " + code + ", Poule: " + poule + ", Regio: " + regio;
        }
    }
}
