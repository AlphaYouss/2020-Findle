using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WPFFINDLE_BAS
{
    class Passwordhandler
    {
        private Databasehandler databasehandler { get; set; } = new Databasehandler();
        private SqlCommand command { get; set; } = new SqlCommand();

        public string GetPasswordhash(string email)
        {
            string password = "";

            command = new SqlCommand("SELECT Password FROM [User] WHERE Email= @email", databasehandler.GetCon());
            command.Parameters.AddWithValue("email", email);

            databasehandler.OpenConnectionToDB();
            password = Convert.ToString(command.ExecuteScalar());
            databasehandler.CloseConnectionToDB();

            command = new SqlCommand();

            return password;
        }

        public string GetPasswordsalt(string email)
        {
            string salt = "";

            command = new SqlCommand("SELECT Salt FROM [User] WHERE Email= @email", databasehandler.GetCon());
            command.Parameters.AddWithValue("email", email);

            databasehandler.OpenConnectionToDB();
            salt = Convert.ToString(command.ExecuteScalar());
            databasehandler.CloseConnectionToDB();

            command = new SqlCommand();

            return salt;
        }

        public bool VerifyPassword(string salt, string password, string passwordHash)
        {
            var saltBytes = Convert.FromBase64String(salt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == passwordHash; ;
        }
    }
}
