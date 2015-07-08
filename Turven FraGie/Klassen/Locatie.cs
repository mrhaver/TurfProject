using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turven_FraGie.Klassen
{
    public class Locatie
    {
        // Fields / Properties
        private int id;
        private string sporthalNaam;
        private string plaats;
        private string postcode;
        private string huisnummer;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string SporthalNaam
        {
            get { return sporthalNaam; }
            set { sporthalNaam = value; }
        }

        public string Plaats
        {
            get { return plaats; }
            set { plaats = value; }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public string Huisnummer
        {
            get { return huisnummer; }
            set { huisnummer = value; }
        }

        // Constructor(s)
        public Locatie(int id, string sporthalNaam, string plaats, string postcode, string huisnummer)
        {
            this.id = id;
            this.sporthalNaam = sporthalNaam;
            this.plaats = plaats;
            this.postcode = postcode;
            this.huisnummer = huisnummer;
        }

        public Locatie()
        {

        }

        // Methods
        public override string ToString()
        {
            return "Sporthal: " + sporthalNaam + ", Plaats: " + plaats;
        }
    }
}
