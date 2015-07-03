using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turven_FraGie.Klassen
{
    public class Vereniging
    {
        // Fields / Properties
        private string naam;

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        // Constructor(s)
        public Vereniging(string naam)
        {
            this.naam = naam;
        }

        // Methods
        public override string ToString()
        {
            return this.naam;
        }
    }
}
