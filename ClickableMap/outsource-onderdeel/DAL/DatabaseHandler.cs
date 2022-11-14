using System;
using System.Data;
using System.Data.SqlClient;

namespace outsource_onderdeel.DAL
{
    public class Databasehandler
    {
        public SqlCommand command;
        public SqlConnectionStringBuilder builder { get; private set; }
        public SqlDataReader dataReader { get; set; }
        private SqlConnection con { get; set; }

        public DataTable table = new DataTable();


        public Databasehandler()
        {
            builder = new SqlConnectionStringBuilder();

            builder.DataSource = "mssql.fhict.local";
            builder.UserID = "dbi440671_outsource";
            builder.Password = "#d2H49Mkj/yZF";
            builder.InitialCatalog = "dbi440671_outsource";

            con = new SqlConnection(builder.ConnectionString);
            //con = new SqlConnection("server=fhict.it-motion.nl;user id=c1fhict;password=kJ9twZMt#;persistsecurityinfo=True;database=c1fhict;allowuservariables=True;convertzerodatetime=True");
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
    }
}