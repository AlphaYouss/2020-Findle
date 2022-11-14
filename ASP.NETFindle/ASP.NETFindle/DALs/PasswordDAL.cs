using System;
using Microsoft.Data.SqlClient;
using ASP.NETFindle.Interface;

namespace ASP.NETFindle.DataBase
{
    public class PasswordDAL : Databasehandler, IPasswordDAL
    {
        public string GetPasswordhash(string email)
        {
            string password = "";

            command = new SqlCommand("SELECT Password FROM [User] WHERE Email= @email", GetCon());
            command.Parameters.AddWithValue("email", email);

            OpenConnectionToDB();
            password = Convert.ToString(command.ExecuteScalar());
            CloseConnectionToDB();

            return password;
        }

        public string GetPasswordsalt(string email)
        {
            string salt = "";

            command = new SqlCommand("SELECT Salt FROM [User] WHERE Email= @email", GetCon());
            command.Parameters.AddWithValue("email", email);

            OpenConnectionToDB();
            salt = Convert.ToString(command.ExecuteScalar());
            CloseConnectionToDB();

            return salt;
        }
    }
}
