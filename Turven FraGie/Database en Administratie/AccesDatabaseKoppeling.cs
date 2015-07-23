using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using Turven_FraGie.Klassen;

namespace Turven_FraGie.Database_en_Administratie
{
    public class AccesDatabaseKoppeling
    {
        private OleDbConnection conn;
        private OleDbCommand command;

        public AccesDatabaseKoppeling()
        {
            string bestandsnaam = @"C:\Users\Frank Haver\Documents\Frank\Turf Project\Implementatie\Turven FraGie\TurfProject\Turven FraGie\bin\Debug/DB_Turven_Fragie.accdb";
            string provider = "Provider=Microsoft.ACE.OLEDB.12.0"; //voor een accdb-database.
            string connectionString = provider + ";Data Source=" + bestandsnaam;
            conn = new OleDbConnection(connectionString);
        }

        #region Haal Lijsten Op
        public List<Vereniging> HaalVerenigingenOp()
        {
            List<Vereniging> tempVereniging = new List<Vereniging>();
            try
            {
                conn.Open();
                string query = "SELECT * FROM VERENIGING ORDER BY 1";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    tempVereniging.Add(new Vereniging(Convert.ToString(dataReader["NAAM"])));
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }

            // wijs nu de locatie aan de vereniging
            try
            {
                conn.Open();
                string query = "SELECT * FROM LOCATIE";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    foreach (Vereniging v in tempVereniging)
                    {
                        if (v.Naam == Convert.ToString(dataReader["VERENIGING_NAAM"]))
                        {
                            v.Locatie.ID = Convert.ToInt32(dataReader["ID"]);
                            v.Locatie.SporthalNaam = Convert.ToString(dataReader["NAAM"]);
                            v.Locatie.Plaats = Convert.ToString(dataReader["PLAATS"]);
                            v.Locatie.Postcode = Convert.ToString(dataReader["POSTCODE"]);
                            v.Locatie.Huisnummer = Convert.ToString(dataReader["HUISNUMMER"]);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }

            try
            {
                conn.Open();
                string query = "SELECT * FROM TEAM";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    foreach (Vereniging v in tempVereniging)
                    {
                        if (v.Naam == Convert.ToString(dataReader["VERENIGING_NAAM"]))
                        {
                            v.Teams.Add(new Team(Convert.ToString(dataReader["VERENIGING_NAAM"]), Convert.ToString(dataReader["TEAMCODE"]), Convert.ToInt32(dataReader["ID"])));
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }

            try
            {
                conn.Open();
                string query = "SELECT s.ID, VOORNAAM, ACHTERNAAM, RUGNUMMER, SPELER_ID, VERENIGING_NAAM FROM SPELER s, SPELER_VERENIGING sv WHERE s.ID = sv.SPELER_ID";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    foreach (Vereniging v in tempVereniging)
                    {
                        if (v.Naam == Convert.ToString(dataReader["VERENIGING_NAAM"]))
                        {
                            v.Spelers.Add(new Speler(Convert.ToInt32(dataReader["ID"]), Convert.ToString(dataReader["VOORNAAM"]), Convert.ToString(dataReader["ACHTERNAAM"]),
                                Convert.ToInt32(dataReader["RUGNUMMER"])));
                        }
                    }
                }
                query = "SELECT p.ID, p.SPELER_ID, VOORNAAM, ACHTERNAAM, RUGNUMMER, ts.TEAM_ID, t.TEAMCODE, POSITIETYPE, sv.VERENIGING_NAAM FROM POSITIE p , SPELER s, SPELER_VERENIGING sv, TEAM_SPELER ts, TEAM t WHERE s.ID = ts.SPELER_ID AND s.ID = sv.SPELER_ID AND p.SPELER_ID = s.ID AND t.ID = ts.TEAM_ID";
                command = new OleDbCommand(query, conn);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    foreach (Vereniging v in tempVereniging)
                    {
                        if (v.Naam == Convert.ToString(dataReader["VERENIGING_NAAM"]))
                        {
                            foreach (Speler s in v.Spelers)
                            {
                                if (s.ID == Convert.ToInt32(dataReader["SPELER_ID"]))
                                {
                                    s.Posities.Add(new Positie(Convert.ToInt32(dataReader["ID"]), Convert.ToInt32(dataReader["SPELER_ID"]), Convert.ToString(dataReader["POSITIETYPE"])));
                                    s.Teams.Add(new Team(Convert.ToString(dataReader["VERENIGING_NAAM"]), Convert.ToString(dataReader["TEAMCODE"]), Convert.ToInt32(dataReader["TEAM_ID"])));
                                }
                            }
                            foreach (Team t in v.Teams)
                            {
                                if (t.ID == Convert.ToInt32(dataReader["TEAM_ID"]))
                                {
                                    t.Spelers.Add(new Speler(Convert.ToInt32(dataReader["SPELER_ID"]), Convert.ToString(dataReader["VOORNAAM"]), Convert.ToString(dataReader["ACHTERNAAM"]),
                                        Convert.ToInt32(dataReader["RUGNUMMER"])));
                                }
                            }
                            foreach (Team t in v.Teams)
                            {
                                if (t.ID == Convert.ToInt32(dataReader["TEAM_ID"]))
                                {
                                    foreach (Speler s in t.Spelers)
                                    {
                                        if (s.ID == Convert.ToInt32(dataReader["SPELER_ID"]))
                                        {
                                            s.Posities.Add(new Positie(Convert.ToInt32(dataReader["ID"]), Convert.ToInt32(dataReader["SPELER_ID"]), Convert.ToString(dataReader["POSITIETYPE"])));
                                            s.Teams.Add(new Team(Convert.ToString(dataReader["VERENIGING_NAAM"]), Convert.ToString(dataReader["TEAMCODE"]), Convert.ToInt32(dataReader["TEAM_ID"])));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return tempVereniging;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Account> HaalAccountsOp()
        {
            List<Account> tempAccounts = new List<Account>();
            try
            {
                conn.Open();
                string query = "SELECT * FROM ACCOUNT";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    tempAccounts.Add(new Account(Convert.ToString(dataReader["INLOGNAAM"]), new Vereniging(Convert.ToString(dataReader["VERENIGING_NAAM"])),
                        Convert.ToString(dataReader["WACHTWOORD"]), Convert.ToString(dataReader["ACCOUNTTYPE"])));
                }
                return tempAccounts;
            }
            catch
            {
                return tempAccounts;
            }
            finally
            {
                conn.Close();
            }

        }

        public List<Competitie> HaalCompetitiesOp()
        {
            List<Competitie> tempCompetities = new List<Competitie>();
            try
            {
                conn.Open();
                string query = "SELECT * FROM COMPETITIE";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    tempCompetities.Add(new Competitie(Convert.ToString(dataReader["CODE"]), Convert.ToString(dataReader["NIVEAU"]), Convert.ToString(dataReader["POULE"]),
                        Convert.ToString(dataReader["REGIO"])));
                }

            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }

            try
            {
                conn.Open();
                string query = "SELECT COMPETITIE_CODE, VERENIGING_NAAM, TEAMCODE, t.ID, ct.TEAM_ID  FROM TEAM t, COMPETITIE_TEAM ct WHERE t.ID = ct.TEAM_ID";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    foreach (Competitie c in tempCompetities)
                    {
                        if (c.Code == Convert.ToString(dataReader["COMPETITIE_CODE"]))
                        {
                            c.Teams.Add(new Team(Convert.ToString(dataReader["VERENIGING_NAAM"]), Convert.ToString(dataReader["TEAMCODE"]), Convert.ToInt32(dataReader["ID"])));
                        }
                    }
                }
                return tempCompetities;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Speler> HaalSpelersOp()
        {
            List<Speler> tempSpelers = new List<Speler>();
            try
            {
                conn.Open();
                string query = "SELECT * FROM SPELER";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    tempSpelers.Add(new Speler(Convert.ToInt32(dataReader["ID"]), Convert.ToString(dataReader["VOORNAAM"]), Convert.ToString(dataReader["ACHTERNAAM"]),
                        Convert.ToInt32(dataReader["RUGNUMMER"])));
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }

            try
            {
                conn.Open();
                string query = "SELECT * FROM POSITIE";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    foreach (Speler s in tempSpelers)
                    {
                        if (s.ID == Convert.ToInt32(dataReader["ID"]))
                        {
                            s.Posities.Add(new Positie(Convert.ToInt32(dataReader["ID"]), Convert.ToInt32(dataReader["SPELER_ID"]), Convert.ToString(dataReader["POSITIETYPE"])));
                        }
                    }
                }
                return tempSpelers;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion
        #region Vereniging
        /// <summary>
        /// Methode die kijkt of een bepaalde vereniging al een beheerder heeft
        /// </summary>
        public bool HeeftBeheerder(string vNaam, out string error)
        {
            error = "";
            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM ACCOUNT WHERE Vereniging_Naam = @vNaam AND AccountType = 'BEHEERDER'";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@vNaam", OleDbType.VarChar).Value = vNaam;
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    if (Convert.ToInt32(dataReader[0]) == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion
        #region Account
        public bool MaakAccount(string inlogNaam, string vNaam, string wachtwoord, string accountType)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO ACCOUNT VALUES(@inlogNaam, @vNaam, @wachtwoord, @accountType)";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("inlogNaam", OleDbType.VarChar).Value = inlogNaam;
                command.Parameters.Add("vNaam", OleDbType.VarChar).Value = vNaam;
                command.Parameters.Add("wachtwoord", OleDbType.VarChar).Value = wachtwoord;
                command.Parameters.Add("accountType", OleDbType.VarChar).Value = accountType;
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion
        #region Competitie

        public bool MaakCompetitie(string code, string niveau, string poule, string regio)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO COMPETITIE VALUES(@code, @niveau, @poule, @regio)";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@code", OleDbType.VarChar).Value = code;
                command.Parameters.Add("@niveau", OleDbType.VarChar).Value = niveau;
                command.Parameters.Add("@poule", OleDbType.VarChar).Value = poule;
                command.Parameters.Add("@regio", OleDbType.VarChar).Value = regio;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool WijzigCompetitie(string code, string niveau, string poule, string regio)
        {
            try
            {
                conn.Open();
                string query = "UPDATE COMPETITIE SET CODE = @code, NIVEAU = @niveau, POULE = @poule, REGIO = @regio WHERE CODE = @code";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@code", OleDbType.VarChar).Value = code;
                command.Parameters.Add("@niveau", OleDbType.VarChar).Value = niveau;
                command.Parameters.Add("@poule", OleDbType.VarChar).Value = poule;
                command.Parameters.Add("@regio", OleDbType.VarChar).Value = regio;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool VerwijderCompetitieTeam(string compCode)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM COMPETITIE_TEAM WHERE COMPETITIE_CODE = @code";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@code", OleDbType.VarChar).Value = compCode;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool VerwijderCompetitie(string compCode)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM COMPETITIE WHERE Code = @code";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@code", OleDbType.VarChar).Value = compCode;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion
        #region Vereniging
        public bool MaakVereniging(string naam)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO VERENIGING VALUES(@naam)";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@naam", OleDbType.VarChar).Value = naam;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool WijsLocatieAanVereniging(string vNaam, string shNaam, string plaats, string postcode, string huisnummer)
        {
            try
            {
                conn.Open();
                int nieuwId = LocatieSeq();
                string query = "INSERT INTO LOCATIE VALUES(p_Locatie, @p_v_Naam, @p_sp_Naam, @p_Plaats, @p_Postcode, @p_HuisNummer)";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@p_Locatie", OleDbType.Integer).Value = nieuwId;
                command.Parameters.Add("@p_v_Naam", OleDbType.VarChar).Value = vNaam;
                command.Parameters.Add("@p_sp_Naam",OleDbType.VarChar).Value = shNaam;
                command.Parameters.Add("@p_Plaats",OleDbType.VarChar).Value = plaats;
                command.Parameters.Add("@p_Postcode",OleDbType.VarChar).Value = postcode;
                command.Parameters.Add("@p_HuisNummer",OleDbType.VarChar).Value = huisnummer;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool WijzigVereniging(string vNaam, string oudVNaam, string shNaam, string plaats, string postcode, string huisnummer, int vID)
        {
            try
            {
                conn.Open();
                string query = "UPDATE VERENIGING SET NAAM = @nNaam WHERE NAAM = @oNaam";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("nNaam", OleDbType.VarChar).Value = vNaam;
                command.Parameters.Add("oNaam", OleDbType.VarChar).Value = oudVNaam;
                command.ExecuteNonQuery();
                query = "UPDATE LOCATIE SET VERENIGING_NAAM = @vNaam, NAAM = @shNaam, PLAATS = @plaats," +
                    "POSTCODE = @postcode, HUISNUMMER = @huisnummer WHERE ID = @id";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@vNaam", OleDbType.VarChar).Value = vNaam;
                command.Parameters.Add("@shNaam", OleDbType.VarChar).Value = shNaam;
                command.Parameters.Add("@plaats", OleDbType.VarChar).Value = plaats;
                command.Parameters.Add("@postcode", OleDbType.VarChar).Value = postcode;
                command.Parameters.Add("@huisnummer", OleDbType.VarChar).Value = huisnummer;
                command.Parameters.Add("@id", OleDbType.Integer).Value = vID;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool VerwijderVereniging(string vNaam)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM TEAM_SPELER WHERE TEAM_ID IN ( SELECT ID FROM TEAM WHERE VERENIGING_NAAM = @vNaam)";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@vNaam", OleDbType.VarChar).Value = vNaam;
                command.ExecuteNonQuery();
                query = "DELETE FROM TEAM WHERE VERENIGING_NAAM = @vNaam";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@vNaam", OleDbType.VarChar).Value = vNaam;
                command.ExecuteNonQuery();
                query = "DELETE FROM LOCATIE WHERE VERENIGING_NAAM = @vNaam";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@vNaam", OleDbType.VarChar).Value = vNaam;
                command.ExecuteNonQuery();
                query = "DELETE FROM ACCOUNT WHERE VERENIGING_NAAM = @vNaam";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@vNaam", OleDbType.VarChar).Value = vNaam;
                command.ExecuteNonQuery();
                query = "DELETE FROM VERENIGING WHERE NAAM = @vNaam";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@vNaam", OleDbType.VarChar).Value = vNaam;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion
        #region Teams
        public bool MaakTeam(string verenigingNaam, string teamCode)
        {
            try
            {
                conn.Open();
                int nieuwId = TeamSeq();
                string query = "INSERT INTO TEAM VALUES(@p_team_id, @p_Vereniging_Naam, @p_Team_Code)";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@p_team_id", OleDbType.Integer).Value = nieuwId;
                command.Parameters.Add("@p_Vereniging_Naam", OleDbType.VarChar).Value = verenigingNaam;
                command.Parameters.Add("@p_Team_Code", OleDbType.VarChar).Value = teamCode;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool WijzigTeam(int id, string teamCode)
        {
            try
            {
                conn.Open();
                string query = "UPDATE TEAM SET TEAMCODE = @teamcode WHERE ID = @id";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("teamcode", OleDbType.VarChar).Value = teamCode;
                command.Parameters.Add("id", OleDbType.Integer).Value = id;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool VerwijderTeam(int id)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM TEAM_SPELER WHERE TEAM_ID = @id";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@id", OleDbType.Integer).Value = id;
                command.ExecuteNonQuery();
                query = "DELETE FROM COMPETITIE_TEAM WHERE TEAM_ID = @id";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@id", OleDbType.Integer).Value = id;
                command.ExecuteNonQuery();
                query = "DELETE FROM TEAM WHERE ID = @id";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@id", OleDbType.Integer).Value = id;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion
        #region Competitie Teams
        public bool WijsTeamAanCompetitie(int teamID, string compCode)
        {
            try
            {
                conn.Open();
                int nieuwID = Competitie_TeamSeq();
                string query = "INSERT INTO COMPETITIE_TEAM VALUES(@p_comp_id, @p_Comp_Code, @p_Team_ID)";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@p_comp_id", OleDbType.Integer).Value = nieuwID;
                command.Parameters.Add("@p_Comp_Code", OleDbType.VarChar).Value = compCode;
                command.Parameters.Add("@p_comp_id", OleDbType.Integer).Value = teamID;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool VerwijderTeamUitCompetitie(int teamID, string compCode)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM COMPETITIE_TEAM WHERE TEAM_ID = @team_id AND COMPETITIE_CODE = @compCode";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@team_id", OleDbType.Integer).Value = teamID;
                command.Parameters.Add("@compCode", OleDbType.VarChar).Value = compCode;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion
        #region Speler
        public bool MaakSpeler(string voornaam, string achternaam, int rugnummer, string favPos, string verenigingNaam, int team_id)
        {
            try
            {
                conn.Open();
                int spelerID = SpelerSeq();
                int positieID = PositieSeq();
                int verenigingID = Speler_VerenigingSeq();
                int team_spelerID = Team_SpelerSeq();
                string query = "INSERT INTO SPELER VALUES(@v_Speler_ID, @p_Voornaam, @p_Achternaam, @p_Rugnummer)";
                command = new OleDbCommand(query, conn);
                
                command.Parameters.Add("@v_Speler_ID", OleDbType.Integer).Value = spelerID;
                command.Parameters.Add("@p_Voornaam", OleDbType.VarChar).Value = voornaam;
                command.Parameters.Add("@p_Achternaam", OleDbType.VarChar).Value = achternaam;
                command.Parameters.Add("@p_Rugnummer", OleDbType.Integer).Value = rugnummer;
                command.ExecuteNonQuery();

                query = "INSERT INTO POSITIE VALUES(@p_positie_id, @v_Speler_ID, @p_Fav_Pos)";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@p_positie_id", OleDbType.Integer).Value = positieID;
                command.Parameters.Add("@v_Speler_ID", OleDbType.Integer).Value = spelerID;
                command.Parameters.Add("@p_Fav_Pos", OleDbType.VarChar).Value = favPos;
                command.ExecuteNonQuery();

                query = "INSERT INTO SPELER_VERENIGING VALUES(@p_spelerv_id, @v_Speler_ID, @p_Vereniging_Naam)";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@p_spelerv_id", OleDbType.Integer).Value = verenigingID;
                command.Parameters.Add("@v_Speler_ID", OleDbType.Integer).Value = spelerID;
                command.Parameters.Add("@p_Vereniging_Naam", OleDbType.VarChar).Value = verenigingNaam;
                command.ExecuteNonQuery();

                query = "INSERT INTO TEAM_SPELER VALUES(@p_team_speler_id, @p_Team_ID, @v_Speler_ID)";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@p_team_speler_id", OleDbType.Integer).Value = team_spelerID;
                command.Parameters.Add("@p_Team_ID", OleDbType.Integer).Value = team_id;
                command.Parameters.Add("@v_Speler_ID", OleDbType.Integer).Value = spelerID;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool WijzigSpeler(int speler_id, string voornaam, string achternaam, int rugnummer, string favPos, string verenigingNaam, int team_id)
        {
            try
            {
                conn.Open();
                string query = "UPDATE SPELER SET VOORNAAM = @voornaam, ACHTERNAAM = @achternaam, RUGNUMMER = @rugnummer WHERE ID = @speler_id";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@voornaam", OleDbType.VarChar).Value = voornaam;
                command.Parameters.Add("@achternaam", OleDbType.VarChar).Value = achternaam;
                command.Parameters.Add("@rugnummer", OleDbType.Integer).Value = rugnummer;
                command.Parameters.Add("@speler_id", OleDbType.Integer).Value = speler_id;
                command.ExecuteNonQuery();
                query = "UPDATE POSITIE SET POSITIETYPE = @favPos WHERE SPELER_ID = @speler_id";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@favPos", OleDbType.VarChar).Value = favPos;
                command.Parameters.Add("@speler_id", OleDbType.Integer).Value = speler_id;
                command.ExecuteNonQuery();
                query = "UPDATE TEAM_SPELER SET TEAM_ID = @team_id WHERE SPELER_ID = @speler_id";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@team_id", OleDbType.Integer).Value = team_id;
                command.Parameters.Add("@speler_id", OleDbType.Integer).Value = speler_id;
                command.ExecuteNonQuery();
                query = "UPDATE SPELER_VERENIGING SET VERENIGING_NAAM = @vereniging_naam WHERE SPELER_ID = @speler_id";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@vereniging_naam", OleDbType.VarChar).Value = verenigingNaam;
                command.Parameters.Add("@speler_id", OleDbType.Integer).Value = speler_id;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool VerwijderSpelerKoppel(int speler_id)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM POSITIE WHERE SPELER_ID = @speler_id";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@speler_id", OleDbType.Integer).Value = speler_id;
                command.ExecuteNonQuery();
                query = "DELETE FROM SPELER_VERENIGING WHERE SPELER_ID = @speler_id";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@speler_id", OleDbType.Integer).Value = speler_id;
                command.ExecuteNonQuery();
                query = "DELETE FROM TEAM_SPELER WHERE SPELER_ID = @speler_id";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@speler_id", OleDbType.Integer).Value = speler_id;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool VerwijderSpeler(int id)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM SPELER WHERE ID = @id";
                command = new OleDbCommand(query, conn);
                command.Parameters.Add("@id", OleDbType.Integer).Value = id;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion
        #region Helper Functies
        /// <summary>
        /// Sequence van team
        /// </summary>
        #region Sequences
        public int TeamSeq()
        {
            try
            {
                string query = "SELECT Max(ID)+1 FROM TEAM";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    return Convert.ToInt32(dataReader[0]);
                }
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
            }
        }

        public int LocatieSeq()
        {
            try
            {
                string query = "SELECT Max(ID)+1 FROM LOCATIE";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    return Convert.ToInt32(dataReader[0]);
                }
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
            }
        }

        public int Competitie_TeamSeq()
        {
            try
            {
                string query = "SELECT Max(ID)+1 FROM COMPETITIE_TEAM";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    return Convert.ToInt32(dataReader[0]);
                }
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
            }
        }

        public int SpelerSeq()
        {
            try
            {
                string query = "SELECT Max(ID)+1 FROM SPELER";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    return Convert.ToInt32(dataReader[0]);
                }
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
            }
        }

        public int PositieSeq()
        {
            try
            {
                string query = "SELECT Max(ID)+1 FROM POSITIE";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    return Convert.ToInt32(dataReader[0]);
                }
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
            }
        }

        public int Speler_VerenigingSeq()
        {
            try
            {
                string query = "SELECT Max(ID)+1 FROM SPELER_VERENIGING";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    return Convert.ToInt32(dataReader[0]);
                }
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
            }
        }

        public int Team_SpelerSeq()
        {
            try
            {
                string query = "SELECT Max(ID)+1 FROM TEAM_SPELER";
                command = new OleDbCommand(query, conn);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    return Convert.ToInt32(dataReader[0]);
                }
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
            }
        }
        #endregion
        

        #endregion
    }
}
