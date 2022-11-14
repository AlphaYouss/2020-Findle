using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WPFFINDLE_BAS
{
    class User
    {
        private Databasehandler databasehandler { get; set; } = new Databasehandler();
        private Passwordhandler passwordhandler { get; set; } = new Passwordhandler();
        private SqlCommand command  { get; set; } = new SqlCommand();
        private List<SearchHistory> searchHistories { get; set; } = new List<SearchHistory>();
        public Location myLocation { get; private set; } = new Location();
        public int id { get; private set; } = 0;
        public string firstname { get;  private set; } = "";
        public string lastname { get; private set; } = "";
        public string email { get; private set; } = "";
        public string profile { get; private set; } = "";
        public string function { get; private set; } = "";
        public bool findable { get; private set; } = false;

        public bool CheckExistance(string email)
        {
            command = new SqlCommand("SELECT COUNT(email) FROM [USER] WHERE email = @email", databasehandler.GetCon());
            command.Parameters.AddWithValue("email", email);

            databasehandler.OpenConnectionToDB();
            if (Convert.ToInt32(command.ExecuteScalar()) != 0)
            {
                databasehandler.CloseConnectionToDB();
                command = new SqlCommand();

                return true;
            }
            else
            {
                databasehandler.CloseConnectionToDB();
                command = new SqlCommand();

                return false;
            }
        }

        public bool LoginUser(string email, string password)
        {
            //GenerateSaltedHash("Welkom12345");
            string[] passwordDetails = new string[2];

            passwordDetails[0] = passwordhandler.GetPasswordhash(email);
            passwordDetails[1] = passwordhandler.GetPasswordsalt(email);

            return passwordhandler.VerifyPassword(passwordDetails[1], password, passwordDetails[0]);
        }

        public void FindMyLocation()
        {
            myLocation.GetUserLocation(email);
        }

        public void GetUserData(string email)
        {
            command = new SqlCommand("SELECT * FROM [USER] WHERE Email = @email", databasehandler.GetCon());
            command.Parameters.AddWithValue("email", email);
            databasehandler.OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(databasehandler.table);

            databasehandler.CloseConnectionToDB();
            command = new SqlCommand();

            SetUserDetails(
            Convert.ToInt32(databasehandler.table.Rows[0]["ID"]),
            Convert.ToString(databasehandler.table.Rows[0]["FirstName"]),
            Convert.ToString(databasehandler.table.Rows[0]["LastName"]),
            Convert.ToString(databasehandler.table.Rows[0]["Email"]),
            Convert.ToString(databasehandler.table.Rows[0]["Profile"]),
            Convert.ToString(databasehandler.table.Rows[0]["UserFunction"]),
            Convert.ToBoolean(databasehandler.table.Rows[0]["Findable"]));

            GetUserSearchHistories();
        }

        public void GetUserSearchHistories()
        {
            databasehandler.ClearTable();

            command = new SqlCommand("SELECT * FROM [SearchHistory] WHERE User_ID = @User_ID", databasehandler.GetCon());
            command.Parameters.AddWithValue("User_ID", id);
            databasehandler.OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(databasehandler.table);

            databasehandler.CloseConnectionToDB();
            command = new SqlCommand();

            foreach (DataRow row in databasehandler.table.Rows)
            {
                SearchHistory history = new SearchHistory();

                history.SetSearchHistory(Convert.ToInt32(row["SearchedUser_ID"]), Convert.ToDateTime(row["Search_At"]));
                SetSearchhistory(history);
            }

            databasehandler.ClearTable();
        }

        public void SetUserDetails(int id,string firstname, string lastname, string email, string profile, string function, bool findable)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.profile = profile;
            this.function = function;
            this.findable = findable;
        }

        public void SetUserLocation(Location location)
        {
            myLocation = location;
        }

        public void SetSearchhistory(SearchHistory searchHistory)
        {
            searchHistories.Add(searchHistory);
        }

        public void SetUserLocation()
        {
            databasehandler.ClearTable();

            command = new SqlCommand("UPDATE [USER] SET Location_ID = @Location_ID WHERE Email = @Email", databasehandler.GetCon());

            command.Parameters.AddWithValue("Email", email);
            command.Parameters.AddWithValue("Location_ID", DBNull.Value);

            databasehandler.OpenConnectionToDB();
            command.ExecuteNonQuery();
            databasehandler.CloseConnectionToDB();

            command = new SqlCommand();

            myLocation = new Location();
        }

        public void SetUserFindable(bool findable)
        {
            command = new SqlCommand("UPDATE [USER] SET Findable = @Findable WHERE Email = @Email", databasehandler.GetCon());

            command.Parameters.AddWithValue("Email", email);
            command.Parameters.AddWithValue("Findable", findable);

            databasehandler.OpenConnectionToDB();
            command.ExecuteNonQuery();
            databasehandler.CloseConnectionToDB();

            command = new SqlCommand();

            this.findable = findable;
        }

        //public void GenerateSaltedHash(string password)
        //{
        //    var saltBytes = new byte[64];
        //    var provider = new RNGCryptoServiceProvider();
        //    provider.GetNonZeroBytes(saltBytes);
        //    var salt = Convert.ToBase64String(saltBytes);

        //    var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
        //    var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

        //    string myHash = hashPassword;
        //    string mySalt = salt;  
        //}
    }
}