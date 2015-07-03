using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turven_FraGie.Klassen;

namespace Turven_FraGie.Database_en_Administratie
{
    /// <summary>
    /// De klasse administratie wordt gebruikt als doorgeefluik van de forms naar de database toe.
    /// Als de formulieren zouden veranderen dan zou er in de database en de administratie niets hoeven veranderen.
    /// </summary>
    public class Administratie
    {
        // Fields / Properties
        DatabaseKoppeling databaseKoppeling;

        public List<Vereniging> Verenigingen
        {
            get { return databaseKoppeling.HaalVerenigingenOp(); }
        }

        public List<Account> Accounts
        {
            get { return databaseKoppeling.HaalAccountsOp(); }
        }

        // Constructor(s)
        public Administratie()
        {
            databaseKoppeling = new DatabaseKoppeling();
        }

        // Methods
        public bool HeeftBeheerder(string vNaam, out string error)
        {
            if(databaseKoppeling.HeeftBeheerder(vNaam, out error))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Account
        public bool MaakAccount(string inlogNaam, string vNaam, string wachtwoord, string accountType)
        {
            if(databaseKoppeling.MaakAccount(inlogNaam, vNaam, wachtwoord, accountType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
