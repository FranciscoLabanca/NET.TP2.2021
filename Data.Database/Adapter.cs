using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        //const string consKeyDefaultCnnString = "ConnStringLocal"
        const string consKeyDefaultCnnString = "ConnStringExpressIS"; //ConnectionString Ignacio
        public SqlConnection sqlConn
        {
            get; set;
        }
        protected void OpenConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            this.sqlConn = new SqlConnection(connString);
            sqlConn.Open();
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;          
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
