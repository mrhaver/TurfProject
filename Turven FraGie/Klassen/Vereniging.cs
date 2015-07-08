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
        private Locatie locatie;

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public Locatie Locatie
        {
            get { return locatie; }
        }

        // Constructor(s)
        public Vereniging(string naam)
        {
            this.naam = naam;
            this.locatie = new Locatie();
        }

        public Vereniging(string naam, Locatie locatie)
        {
            this.naam = naam;
            this.locatie = locatie;
        }

        // Methods

        public override string ToString()
        {
            return "Naam: " + this.naam + ", Sporthal: " + this.locatie.SporthalNaam + ", Plaats: " + this.locatie.Plaats;
        }
    }
}
