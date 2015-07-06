using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using Turven_FraGie.Klassen;

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
                return tempVereniging;
            }
            catch(Exception)
            {
                return tempVereniging;
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
                return tempCompetities;
            }
            catch
            {
                return tempCompetities;
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

        public bool VerwijderTeamSpelers(string compCode)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM TEAM_SPELER WHERE Team_ID IN ( SELECT ID  FROM TEAM WHERE Competitie_Code = :code)";
                command = new OracleCommand(query, conn);
                command.Parameters.Add("code", OracleDbType.Varchar2).Value = compCode;
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

        public bool VerwijderTeams(string compCode)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM TEAM WHERE Competitie_Code = :code";
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


    }
}
