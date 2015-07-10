using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using Turven_FraGie.Klassen;
using System.Data;

namespace Turven_FraGie
{
    public class DatabaseKoppeling
    {
        // Fields / Properties

        // Constructor(s)
        // Lege constructor om alleen de methoden van deze klasse aan te kunnen
        private OracleConnection conn;
        private OracleCommand command;
        
        public DatabaseKoppeling()
        {
            string user = "TURVEN";
            string pw = "FRAGIE";
            conn = new OracleConnection();
            command = conn.CreateCommand();
            conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + " //localhost:1521/xe" + ";";
        }

        // Methods
        #region Haal Lijsten Op
        public List<Vereniging> HaalVerenigingenOp()
        {
            List<Vereniging> tempVereniging = new List<Vereniging>();
            try
            {
                conn.Open();
                string query = "SELECT * FROM VERENIGING ORDER BY 1";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    tempVereniging.Add(new Vereniging(Convert.ToString(dataReader["NAAM"])));
                }
            }
            catch(Exception)
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
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    foreach(Vereniging v in tempVereniging)
                    {
                        if(v.Naam == Convert.ToString(dataReader["VERENIGING_NAAM"]))
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
            catch(Exception)
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
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
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
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while(dataReader.Read())
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
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
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
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    foreach(Competitie c in tempCompetities)
                    {
                        if(c.Code == Convert.ToString(dataReader["COMPETITIE_CODE"]))
                        {
                            c.Teams.Add(new Team(Convert.ToString(dataReader["VERENIGING_NAAM"]), Convert.ToString(dataReader["TEAMCODE"]), Convert.ToInt32(dataReader["ID"])));
                        }
                    }
                }
                return tempCompetities;
            }
            catch(Exception)
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
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    tempSpelers.Add(new Speler(Convert.ToInt32(dataReader["ID"]), Convert.ToString(dataReader["VOORNAAM"]), Convert.ToString(dataReader["ACHTERNAAM"]),
                        Convert.ToInt32(dataReader["RUGNUMMER"])));
                }
            }
            catch(Exception)
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
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    foreach(Speler s in tempSpelers)
                    {
                        if(s.ID == Convert.ToInt32(dataReader["ID"]))
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
                string query = "SELECT COUNT(*) FROM ACCOUNT WHERE Vereniging_Naam = :vNaam AND AccountType = 'BEHEERDER'";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("vNaam", OracleDbType.Varchar2).Value = vNaam;
                OracleDataReader dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    if(Convert.ToInt32(dataReader[0]) == 0)
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
            catch(Exception ex)
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
                string query = "INSERT INTO ACCOUNT VALUES(:inlogNaam, :vNaam, :wachtwoord, :accountType)";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("inlogNaam", OracleDbType.Varchar2).Value = inlogNaam;
                command.Parameters.Add("vNaam", OracleDbType.Varchar2).Value = vNaam;
                command.Parameters.Add("wachtwoord", OracleDbType.Varchar2).Value = wachtwoord;
                command.Parameters.Add("accountType", OracleDbType.Varchar2).Value = accountType;
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
                string query = "INSERT INTO COMPETITIE VALUES(:code, :niveau, :poule, :regio)";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("code", OracleDbType.Varchar2).Value = code;
                command.Parameters.Add("niveau", OracleDbType.Varchar2).Value = niveau;
                command.Parameters.Add("poule", OracleDbType.Varchar2).Value = poule;
                command.Parameters.Add("regio", OracleDbType.Varchar2).Value = regio;
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
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
                string query = "UPDATE COMPETITIE SET CODE = :code, NIVEAU = :niveau, POULE = :poule, REGIO = :regio WHERE CODE = :code";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("code", OracleDbType.Varchar2).Value = code;
                command.Parameters.Add("niveau", OracleDbType.Varchar2).Value = niveau;
                command.Parameters.Add("poule", OracleDbType.Varchar2).Value = poule;
                command.Parameters.Add("regio", OracleDbType.Varchar2).Value = regio;
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
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
                string query = "DELETE FROM COMPETITIE_TEAM WHERE COMPETITIE_CODE = :code";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("code", OracleDbType.Varchar2).Value = compCode;
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
                string query = "DELETE FROM COMPETITIE WHERE Code = :code";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("code", OracleDbType.Varchar2).Value = compCode;
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
                string query = "INSERT INTO VERENIGING VALUES(:naam)";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("naam", OracleDbType.Varchar2).Value = naam;
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
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
                command = new OracleCommand("WIJSLOCATIEAANVERENIGING", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_V_NAAM", OracleDbType.Varchar2).Value = vNaam;
                command.Parameters.Add("P_SP_NAAM", OracleDbType.Varchar2).Value = shNaam;
                command.Parameters.Add("P_PLAATS", OracleDbType.Varchar2).Value = plaats;
                command.Parameters.Add("P_POSTCODE", OracleDbType.Varchar2).Value = postcode;
                command.Parameters.Add("P_HUISNUMMER", OracleDbType.Varchar2).Value = huisnummer;
                
                conn.Open();
                OracleDataAdapter da = new OracleDataAdapter(command);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
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
                string query = "UPDATE VERENIGING SET NAAM = :nNaam WHERE NAAM = :oNaam";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("nNaam", OracleDbType.Varchar2).Value = vNaam;
                command.Parameters.Add("oNaam", OracleDbType.Varchar2).Value = oudVNaam;
                command.ExecuteNonQuery();
                query = "UPDATE LOCATIE SET VERENIGING_NAAM = :vNaam, NAAM = :shNaam, PLAATS = :plaats," +
                    "POSTCODE = :postcode, HUISNUMMER = :huisnummer WHERE ID = :id";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("vNaam", OracleDbType.Varchar2).Value = vNaam;
                command.Parameters.Add("shNaam", OracleDbType.Varchar2).Value = shNaam;
                command.Parameters.Add("plaats", OracleDbType.Varchar2).Value = plaats;
                command.Parameters.Add("postcode", OracleDbType.Varchar2).Value = postcode;
                command.Parameters.Add("huisnummer", OracleDbType.Varchar2).Value = huisnummer;
                command.Parameters.Add("id", OracleDbType.Int32).Value = vID;
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
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
                string query = "DELETE FROM TEAM_SPELER WHERE TEAM_ID IN ( SELECT ID FROM TEAM WHERE VERENIGING_NAAM = :vNaam)";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("vNaam", OracleDbType.Varchar2).Value = vNaam;
                command.ExecuteNonQuery();
                query = "DELETE FROM TEAM WHERE VERENIGING_NAAM = :vNaam";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("vNaam", OracleDbType.Varchar2).Value = vNaam;
                command.ExecuteNonQuery();
                query = "DELETE FROM LOCATIE WHERE VERENIGING_NAAM = :vNaam";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("vNaam", OracleDbType.Varchar2).Value = vNaam;
                command.ExecuteNonQuery();
                query = "DELETE FROM ACCOUNT WHERE VERENIGING_NAAM = :vNaam";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("vNaam", OracleDbType.Varchar2).Value = vNaam;
                command.ExecuteNonQuery();
                query = "DELETE FROM VERENIGING WHERE NAAM = :vNaam";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("vNaam", OracleDbType.Varchar2).Value = vNaam;
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
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
                command = new OracleCommand("MAAKTEAM", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_VERENIGING_NAAM", OracleDbType.Varchar2).Value = verenigingNaam;
                command.Parameters.Add("P_TEAM_CODE", OracleDbType.Varchar2).Value = teamCode;
                conn.Open();
                OracleDataAdapter da = new OracleDataAdapter(command);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
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
                string query = "UPDATE TEAM SET TEAMCODE = :teamcode WHERE ID = :id";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("teamcode", OracleDbType.Varchar2).Value = teamCode;
                command.Parameters.Add("id", OracleDbType.Int32).Value = id;
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
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
                string query = "DELETE FROM TEAM WHERE ID = :id";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("id", OracleDbType.Int32).Value = id;
                command.ExecuteNonQuery();
                query = "DELETE FROM TEAM_SPELER WHERE TEAM_ID = :id";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("id", OracleDbType.Int32).Value = id;
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
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
                command = new OracleCommand("WIJSTEAMAANCOMP", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_COMP_CODE", OracleDbType.Varchar2).Value = compCode;
                command.Parameters.Add("P_TEAM_ID", OracleDbType.Int32).Value = teamID;
                conn.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
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
                string query = "DELETE FROM COMPETITIE_TEAM WHERE TEAM_ID = :team_id AND COMPETITIE_CODE = :compCode";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("team_id", OracleDbType.Int32).Value = teamID;
                command.Parameters.Add("compCode", OracleDbType.Varchar2).Value = compCode;
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
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
        public bool MaakSpeler(string voornaam, string achternaam, int rugnummer, string favPos)
        {
            try
            {
                command = new OracleCommand("MAAKSPELER", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_VOORNAAM", OracleDbType.Varchar2).Value = voornaam;
                command.Parameters.Add("P_ACHTERNAAM", OracleDbType.Varchar2).Value = achternaam;
                command.Parameters.Add("P_RUGNUMMER", OracleDbType.Int32).Value = rugnummer;
                command.Parameters.Add("P_FAV_POS", OracleDbType.Varchar2).Value = favPos;
                conn.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool WijzigSpeler(int speler_id, string voornaam, string achternaam, int rugnummer, string favPos)
        {
            try
            {
                conn.Open();
                string query = "UPDATE SPELER SET VOORNAAM = :voornaam, ACHTERNAAM = :achternaam, RUGNUMMER = :rugnummer WHERE ID = :speler_id";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("voornaam", OracleDbType.Varchar2).Value = voornaam;
                command.Parameters.Add("achternaam", OracleDbType.Varchar2).Value = achternaam;
                command.Parameters.Add("rugnummer", OracleDbType.Int32).Value = rugnummer;
                command.Parameters.Add("speler_id", OracleDbType.Int32).Value = speler_id;
                command.ExecuteNonQuery();
                query = "UPDATE POSITIE SET POSITIETYPE = :favPos WHERE SPELER_ID = :speler_id";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("favPos", OracleDbType.Varchar2).Value = favPos;
                command.Parameters.Add("speler_id", OracleDbType.Int32).Value = speler_id;
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool VerwijderSpelerPos(int speler_id)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM POSITIE WHERE SPELER_ID = :speler_id";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("speler_id", OracleDbType.Int32).Value = speler_id;
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
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
                string query = "DELETE FROM SPELER WHERE ID = :id";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("id", OracleDbType.Int32).Value = id;
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }
}
