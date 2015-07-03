using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Turven_FraGie
{
    public class DatabaseKoppeling
    {
        // Fields / Properties

        // Constructor(s)
        // Lege constructor om alleen de methoden van deze klasse aan te kunnen
        private OracleConnection conn;
        private OracleCommand command;
        string connectionstring;
        
        public DatabaseKoppeling()
        {
            string user = "TURVEN";
            string pw = "FRAGIE";
            conn = new OracleConnection();
            command = conn.CreateCommand();
            conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + " //localhost:1521/xe" + ";";
        }

        // Methods
    }
}
