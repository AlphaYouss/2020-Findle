using System;
using System.Data;
using System.Data.SqlClient;

namespace WPFFINDLE_BAS
{
    class Databasehandler
    {
        public SqlConnectionStringBuilder builder { get; private set; }
        public SqlConnection con { get; private set; }
        public DataTable table { get; private set; }
        public Databasehandler()
        {
            builder = new SqlConnectionStringBuilder();

            builder.DataSource = "mssql.fhict.local";
            builder.UserID = "dbi440671_findle";
            builder.Password = "ep7Vpwm4";
            builder.InitialCatalog = "dbi440671_findle";

            con = new SqlConnection(builder.ConnectionString);
            table = new DataTable();
        }

        public bool TestConnection()
        {
            bool open = false;

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    open = true;
                    con.Close();
                }
            }
            catch (Exception)
            {
                open = false;
            }
            return open;
        }

        public void OpenConnectionToDB()
        {
            con.Open();
        }

        public void CloseConnectionToDB()
        {
            con.Close();
        }

        public SqlConnection GetCon()
        {
            return con;
        }

        public void ClearTable()
        {
            table.Clear();
        }
    }
}
