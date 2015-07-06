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
        private DatabaseKoppeling databaseKoppeling;
        private static Account nuIngelogd;

        public Account NuIngelogd
        {
            get { return nuIngelogd; }
            set { nuIngelogd = value; }
        }

        public List<Vereniging> Verenigingen
        {
            get { return databaseKoppeling.HaalVerenigingenOp(); }
        }

        public List<Account> Accounts
        {
            get { return databaseKoppeling.HaalAccountsOp(); }
        }

        public List<Competitie> Competities
        {
            get { return databaseKoppeling.HaalCompetitiesOp(); }
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

        public Account GeefAccount(string inlogNaam)
        {
            foreach(Account a in Accounts)
            {
                if(inlogNaam == a.InlogNaam)
                {
                    return a;
                }
            }
            return null;
        }
        #endregion

        #region Competitie

        /// <summary>
        /// check even of de code niet al bestaat
        /// </summary>
        public bool MaakCompetitie(string code, string niveau, string poule, string regio, out string error)
        {
            error = "";
            foreach(Competitie c in Competities)
            {
                if(c.Code == code)
                {
                    error = "Competitiecode bestaat al";
                    return false;
                }
            }
            if(!databaseKoppeling.MaakCompetitie(code, niveau, poule, regio))
            {
                error = "Fout in de database";
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// de code moet bestaan anders kan er niets worden aangepast
        /// </summary>
        public bool WijzigCompetitie(string code, string niveau, string poule, string regio, out string error)
        {
            foreach(Competitie c in Competities)
            {
                if(c.Code == code)
                {
                    // voor deze code moet worden upgedate
                    if(!databaseKoppeling.WijzigCompetitie(code, niveau, poule, regio))
                    {
                        error = "Fout in de database";
                        return false;
                    }
                    else
                    {
                        error = "";
                        return true;
                    }
                }
            }
            error = "Competitiecode kon niet gevonden worden";
            return false;
        }

        /// <summary>
        /// Als er een competitie verwijderd moet worden dan moeten ook alle child records verwijderd worden
        /// Dat zijn in dit geval de team_spelers en de teams
        /// </summary>
        public bool VerwijderCompetitie(string compCode, out string error)
        {
            error = "";
            foreach (Competitie c in Competities)
            {
                if (c.Code == compCode)
                {
                    if (databaseKoppeling.VerwijderTeamSpelers(compCode))
                    {
                        if (databaseKoppeling.VerwijderTeams(compCode))
                        {
                            if (databaseKoppeling.VerwijderCompetitie(compCode))
                            {
                                return true;
                            }
                            else
                            {
                                error = "Competities konden niet verwijderd worden";
                                return false;
                            }
                        }
                        else
                        {
                            error = "Teams konden niet verwijderd worden";
                            return false;
                        }
                    }
                    else
                    {
                        error = "Team Spelers konden niet verwijderd worden";
                        return false;
                    }
                }
            }
            error = "Competitiecode kon niet gevonden worden";
            return false;
        }

        #endregion
    }
}
