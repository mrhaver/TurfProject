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
                    if (databaseKoppeling.VerwijderCompetitieTeam(compCode))
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
                        error = "Team Spelers konden niet verwijderd worden";
                        return false;
                    }
                }
            }
            error = "Competitiecode kon niet gevonden worden";
            return false;
        }

        #endregion
        #region Vereniging
        public bool MaakVereniging(string vNaam, string shNaam, string plaats, string postcode, string huisnummer, out string error)
        {
            foreach(Vereniging v in Verenigingen)
            {
                if(v.Naam == vNaam)
                {
                    error = "Vereniging bestaat al";
                    return false;
                }
            }
            if(postcode.Length > 6)
            {
                error = "Postcode mag maar een maximale lengte van 6 hebben";
                return false;
            }
            if (databaseKoppeling.MaakVereniging(vNaam))
            {
                if (databaseKoppeling.WijsLocatieAanVereniging(vNaam, shNaam, plaats, postcode, huisnummer))
                {
                    error = "";
                    return true;
                }
                else
                {
                    error = "Locatie niet toe kunnen voegen";
                    return false;
                }
            }
            else
            {
                error = "Vereniging niet aan kunnen maken";
                return false;
            }          
        }

        public bool WijzigVereniging(string vNaam, string oudVNaam, string shNaam, string plaats, string postcode, string huisnummer, int vID, out string error)
        {
            if (postcode.Length > 6)
            {
                error = "Postcode mag maar een maximale lengte van 6 hebben";
                return false;
            }
            if(databaseKoppeling.WijzigVereniging(vNaam, oudVNaam, shNaam, plaats, postcode, huisnummer, vID))
            {
                error = "";
                return true;
            }
            else
            {
                error = "Vereniging kon niet gewijzigd worden";
                return false;
            }
        }

        public bool VerwijderVereniging(string vNaam)
        {
            if(databaseKoppeling.VerwijderVereniging(vNaam))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
        #region Team

        public bool MaakTeam(string verenigingNaam, string teamCode, out string error)
        {
            // check of de naam al dan niet bestaat
            foreach(Vereniging v in Verenigingen)
            {
                if(v.Naam == verenigingNaam)
                {
                    foreach(Team t in v.Teams)
                    {
                        if(t.TeamCode == teamCode)
                        {
                            error = "Teamcode bestaat al";
                            return false;
                        }
                    }                   
                }
            }
            if (!databaseKoppeling.MaakTeam(verenigingNaam, teamCode))
            {
                error = "Fout in de database raadpleeg de applicatiebeheerder";
                return false;
            }
            else
            {
                error = "";
                return true;
            }
        }

        public bool WijzigTeam(string verenigingNaam, int id, string teamCode, out string error)
        {
            foreach (Vereniging v in Verenigingen)
            {
                if (v.Naam == verenigingNaam)
                {
                    foreach (Team t in v.Teams)
                    {
                        if (t.TeamCode == teamCode)
                        {
                            error = "Teamcode bestaat al";
                            return false;
                        }
                    }
                }
            }
            if(!databaseKoppeling.WijzigTeam(id, teamCode))
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

        public bool VerwijderTeam(int id)
        {
            if(!databaseKoppeling.VerwijderTeam(id))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Team GeefTeamVer(string verenigingNaam, string teamCode)
        {
            foreach(Vereniging v in Verenigingen)
            {
                if(v.Naam == verenigingNaam)
                {
                    foreach(Team t in v.Teams)
                    {
                        if(t.TeamCode == teamCode)
                        {
                            return t;
                        }
                    }
                }
            }
            return null;
        }
        
        #endregion
        #region Competitie Teams

        public bool WijsTeamAanCompetitie(int teamID, string compCode, out string error)
        {
            // check of het team al dan niet in de competitie zit
            foreach(Competitie c in Competities)
            {
                if(c.Code == compCode)
                {
                    foreach(Team t in c.Teams)
                    {
                        if(t.ID == teamID)
                        {
                            error = "Team zit al in de competitie";
                            return false;
                        }
                    }
                }
            }
            if (!databaseKoppeling.WijsTeamAanCompetitie(teamID, compCode))
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
        
        public bool VerwijderTeamUitCompetitie(int teamID, string compCode)
        {
            if(!databaseKoppeling.VerwijderTeamUitCompetitie(teamID, compCode))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion
        #region Speler
        public bool MaakSpeler(string voornaam, string achternaam, int rugnummer, string favPos, string verenigingNaam, int team_ID, out string error)
        {
            // check of het rugnummer al dan niet bezet is
            if(!CheckRugnummer(verenigingNaam, team_ID, rugnummer, out error))
            {
                return false;
            }
            if(!databaseKoppeling.MaakSpeler(voornaam, achternaam, rugnummer, favPos, verenigingNaam, team_ID))
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

        public bool WijzigSpeler(int speler_id, string voornaam, string achternaam, int rugnummer, string favPos, string verenigingNaam, int team_id, int oudRugnummer, int oudTeam_id, out string error)
        {
            if(favPos.ToUpper() == "BUITEN" || favPos.ToUpper() == "MIDDEN" || favPos.ToUpper() == "DIAGONAAL" || favPos.ToUpper() == "SPELVERDELER" || favPos.ToUpper() == "LIBERO")
            {
                // als het team veranderd en het rugnummer blijft hetzelfde dan moet er gewoon gecheckt worden of het rugnummer in het andere team wel bestaat
                // als het team hetzelfde blijft en het rugnummer veranderd moet er gecheckt worden
                // als het team veranderd en het rugnummer veranderd moet er gecheckt worden
                // als het team hetzelfde blijft en het rugnummer blijft hetzelfde moet er NIET gecheckt worden.
                if(team_id == oudTeam_id)
                {
                    if(oudRugnummer != rugnummer)
                    {
                        if(!CheckRugnummer(verenigingNaam, team_id, rugnummer, out error))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if(!CheckRugnummer(verenigingNaam, team_id, rugnummer, out error))
                    {
                        return false;
                    }
                }
                                
                if (!databaseKoppeling.WijzigSpeler(speler_id, voornaam, achternaam, rugnummer, favPos, verenigingNaam, team_id))
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
            else
            {
                error = "Positie moet Buiten, Midden, Diagonaal, Spelverdeler of Libero zijn";
                return false;
            }
        }

        /// <summary>
        /// Apart verwijderen want anders kwam er een foutmelding!
        /// </summary>
        public bool VerwijderSpeler(int speler_id)
        {
            // verwijder uit alle koppeltabellen
            if(!databaseKoppeling.VerwijderSpelerKoppel(speler_id))
            {
                return false;                
            }
            else
            {
                if (!databaseKoppeling.VerwijderSpeler(speler_id))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool CheckRugnummer(string verenigingNaam, int team_id, int rugnummer, out string error)
        {
            error = "";
            foreach (Vereniging v in Verenigingen)
            {
                if (v.Naam == verenigingNaam)
                {
                    foreach (Team t in v.Teams)
                    {
                        if (t.ID == team_id)
                        {
                            foreach (Speler s in t.Spelers)
                            {
                                if (s.Rugnummer == rugnummer)
                                {
                                    error = "Rugnummer bestaat al in dit team";
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        #endregion
    }
}
