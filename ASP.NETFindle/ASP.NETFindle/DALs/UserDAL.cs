using System;
using System.Data;
using Microsoft.Data.SqlClient;
using ASP.NETFindle.Tools;
using ASP.NETFindle.Models;
using ASP.NETFindle.Interface;

namespace ASP.NETFindle.DataBase
{
    public class UserDAL : Databasehandler, IUserDAL
    {
        IPasswordDAL passwordDAL = new PasswordDAL();

        public bool CheckUserExists(string email)
        {
            command = new SqlCommand("SELECT COUNT(email) FROM [USER] WHERE email = @email", GetCon());
            command.Parameters.AddWithValue("email", email);

            bool userExists = false;

            OpenConnectionToDB();

            if (Convert.ToInt32(command.ExecuteScalar()) != 0)
            {
                userExists = true;
            }
            else
            {
                userExists = false;
            }
            CloseConnectionToDB();
            return userExists;
        }

        public bool CheckPasswordIsCorrect(string email, string password)
        {
            string passwordHash = passwordDAL.GetPasswordhash(email);
            string passswordSalt = passwordDAL.GetPasswordsalt(email);
            bool isPasswordCorrect = Passwordhandler.VerifyPassword(passswordSalt, password, passwordHash);

            return isPasswordCorrect;
        }

        public User UserLogin(string email, string password, bool isPasswordCorrect)
        {
            User user = new User();

            if (isPasswordCorrect)
            {
                command = new SqlCommand("SELECT * FROM [USER] WHERE Email = @email", GetCon());
                command.Parameters.AddWithValue("email", email);

                OpenConnectionToDB();

                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    user.Id = Convert.ToInt32(dataReader["ID"]);

                    if (dataReader["Location_ID"] == DBNull.Value)
                    {
                        user.location_Id = 0;
                    }
                    else
                    {
                        user.location_Id = Convert.ToInt32(dataReader["Location_ID"]);
                    }

                    user.Firstname = dataReader["FirstName"].ToString();
                    user.Lastname = dataReader["LastName"].ToString();
                    user.Email = dataReader["Email"].ToString();
                    user.Profile = dataReader["Profile"].ToString();
                    user.UserFunction = dataReader["UserFunction"].ToString();
                    user.Findable = Convert.ToBoolean(dataReader["Findable"]);
                }
                dataReader.Close();
                CloseConnectionToDB();
            }
            return user;
        }

        public void EditUser(int id, string password)
        {
            string[] passwordData =  Passwordhandler.GenerateSaltAndHash(password);

            command = new SqlCommand("UPDATE [USER] SET Password = @Password, Salt = @Salt WHERE ID = @ID", GetCon());

            command.Parameters.AddWithValue("Password", passwordData[0]);
            command.Parameters.AddWithValue("Salt", passwordData[1]);
            command.Parameters.AddWithValue("ID", id);

            OpenConnectionToDB();
            command.ExecuteNonQuery();
            CloseConnectionToDB();
        }

        public void SetUserFindable(bool findable, int userID)
        {
            command = new SqlCommand("UPDATE [USER] SET Findable = @findable WHERE ID = @userID", GetCon());
            command.Parameters.AddWithValue("@findable", findable);
            command.Parameters.AddWithValue("@userID", userID);

            OpenConnectionToDB();
            command.ExecuteNonQuery();
            CloseConnectionToDB();
        }

        public DataTable UserSearch(int userID, string name)
        {
            string[] splitted = name.Split(new[] { ' ' }, 2);

            splitted[0] = splitted[0].TrimStart();
            splitted[0] = splitted[0].TrimEnd();

            if (splitted.Length == 1)
            {
                command = new SqlCommand("SELECT FirstName AS Forename, LastName AS Surname, Profile, UserFunction AS Type, Findable AS Searchable, ID FROM [USER] WHERE Firstname LIKE '%' + @input + '%' AND NOT ID = @userID OR Lastname LIKE '%' + @input + '%' AND NOT ID = @userID", GetCon());
                command.Parameters.AddWithValue("input", splitted[0]);
                command.Parameters.AddWithValue("userID", userID);
            }
            else
            {
                splitted[1] = splitted[1].Trim();

                command = new SqlCommand("SELECT FirstName AS Forename, LastName AS Surname, Profile, UserFunction AS Type, Findable AS Searchable, ID FROM [USER] WHERE Firstname LIKE '%' + @input1 + '%' AND NOT ID = @userID AND Lastname LIKE '%' + @input2 + '%' AND NOT ID = @userID", GetCon());
                command.Parameters.AddWithValue("input1", splitted[0]);
                command.Parameters.AddWithValue("input2", splitted[1]);
                command.Parameters.AddWithValue("userID", userID);
            }

            DataTable table = new DataTable();

            OpenConnectionToDB();

            try
            {
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                adapt.Fill(table);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                CloseConnectionToDB();
            }
            return table;
        }

        public User UserGet(int id)
        {
            User user = new User();

            command = new SqlCommand("SELECT * FROM [USER] WHERE ID = @id", GetCon());
            command.Parameters.AddWithValue("@id", id);

            OpenConnectionToDB();

            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                user.Id = Convert.ToInt32(dataReader["ID"]);

                if (dataReader["Location_ID"] == DBNull.Value)
                {
                    user.location_Id = 0;
                }
                else
                {
                    user.location_Id = Convert.ToInt32(dataReader["Location_ID"]);
                }

                user.Firstname = dataReader["FirstName"].ToString();
                user.Lastname = dataReader["LastName"].ToString();
                user.Email = dataReader["Email"].ToString();
                user.Profile = dataReader["Profile"].ToString();
                user.UserFunction = dataReader["UserFunction"].ToString();
                user.Findable = Convert.ToBoolean(dataReader["Findable"]);
            }

            dataReader.Close();
            CloseConnectionToDB();

            return user;
        }

        public bool GetUserFindable(int userID)
        {
            bool findable = false;

            command = new SqlCommand("SELECT Findable FROM [USER] WHERE ID = @userID", GetCon());
            command.Parameters.AddWithValue("@userID", userID);

            OpenConnectionToDB();

            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                findable = Convert.ToBoolean(dataReader["Findable"]);
            }
            dataReader.Close();
            CloseConnectionToDB();

            return findable;
        }

        public User UpdateUserLocation(int userID, int locationID)
        {
            SqlCommand updateLocation = new SqlCommand("UPDATE [User] SET Location_ID = @Location_ID WHERE ID = @User_ID", GetCon());
            updateLocation.Parameters.AddWithValue("Location_ID", locationID);
            updateLocation.Parameters.AddWithValue("User_ID", userID);

            SqlCommand getUserData = new SqlCommand("SELECT * FROM [User] WHERE ID = @User_ID", GetCon());
            getUserData.Parameters.AddWithValue("User_ID", userID);

            DataTable table = new DataTable();
            User user = new User();

            OpenConnectionToDB();

            updateLocation.ExecuteNonQuery();
            dataReader = getUserData.ExecuteReader();

            while (dataReader.Read())
            {
                user.Id = Convert.ToInt32(dataReader["ID"]);

                if (dataReader["Location_ID"] == DBNull.Value)
                {
                    user.location_Id = 0;
                }
                else
                {
                    user.location_Id = Convert.ToInt32(dataReader["Location_ID"]);
                }

                user.Firstname = dataReader["FirstName"].ToString();
                user.Lastname = dataReader["LastName"].ToString();
                user.Email = dataReader["Email"].ToString();
                user.Profile = dataReader["Profile"].ToString();
                user.UserFunction = dataReader["UserFunction"].ToString();
                user.Findable = Convert.ToBoolean(dataReader["Findable"]);
            }

            return user;
        }

        public int GetUserLocation(int userID)
        {
            SqlCommand cmd = new SqlCommand("SELECT Location_ID FROM [User] WHERE ID = @User_ID", GetCon());
            cmd.Parameters.AddWithValue("User_ID", userID);

            DataTable table = new DataTable();

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(table);

            CloseConnectionToDB();

            int location = Convert.ToInt32(table.Rows[0][0]);
            return location;
        }
    }
}