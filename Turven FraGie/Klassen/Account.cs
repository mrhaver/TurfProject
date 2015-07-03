using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turven_FraGie.Klassen
{
    public class Account
    {
        // Fields / Properties
        private string inlogNaam;
        private Vereniging vereniging;
        private string wachtwoord;
        private string accountType;

        public string InlogNaam
        {
            get { return inlogNaam; }
        }

        // Constructor(s)
        public Account(string inlogNaam, Vereniging vereniging, string wachtwoord, string accountType)
        {
            this.inlogNaam = inlogNaam;
            this.vereniging = vereniging;
            this.wachtwoord = wachtwoord;
            this.accountType = accountType;
        }

        // Methods
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
