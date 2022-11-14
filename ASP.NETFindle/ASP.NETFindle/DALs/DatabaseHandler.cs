using Microsoft.Data.SqlClient;

namespace ASP.NETFindle.DataBase
{
    public class Databasehandler
    {
        public SqlCommand command { get; set; }
        private SqlConnectionStringBuilder builder { get; set; }
        public SqlDataReader dataReader { get; set; }
        private SqlConnection con { get; set; }
        public Databasehandler()
        {
            builder = new SqlConnectionStringBuilder();

            builder.DataSource = "mssql.fhict.local";
            builder.UserID = "dbi440671_outsource";
            builder.Password = "#d2H49Mkj/yZF";
            builder.InitialCatalog = "dbi440671_outsource";

            //builder.DataSource = "mssql.fhict.local";
            //builder.UserID = "dbi440671_findle";
            //builder.Password = "ep7Vpwm4";
            //builder.InitialCatalog = "dbi440671_findle";

            con = new SqlConnection(builder.ConnectionString);
            //con = new SqlConnection("server=fhict.it-motion.nl;user id=c1fhict;password=kJ9twZMt#;persistsecurityinfo=True;database=c1fhict;allowuservariables=True;convertzerodatetime=True");
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