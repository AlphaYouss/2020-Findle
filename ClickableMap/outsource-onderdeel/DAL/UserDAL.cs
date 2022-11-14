using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using outsource_onderdeel.Models.ViewModels;
using outsource_onderdeel.Interfaces;

namespace outsource_onderdeel.DAL
{
    public class UserDAL : Databasehandler, IUser
    {
        MapDAL dal = new MapDAL();

        public UserViewModel InsertUserLocationByID(int UId, int LId)
        {
            SqlCommand UpdateLocation = new SqlCommand("UPDATE [User] SET Location_ID = @Location_ID WHERE ID = @User_ID", GetCon());
            UpdateLocation.Parameters.AddWithValue("Location_ID", LId);
            UpdateLocation.Parameters.AddWithValue("User_ID", UId);

            SqlCommand GetUserData = new SqlCommand("SELECT * FROM [User] WHERE ID = @User_ID", GetCon());
            GetUserData.Parameters.AddWithValue("User_ID", UId);

            OpenConnectionToDB();

            UpdateLocation.ExecuteNonQuery();

            SqlDataAdapter adapt = new SqlDataAdapter(GetUserData);
            table.Clear();
            adapt.Fill(table);

            CloseConnectionToDB();

            //UserViewModel User = dal.DataSetToUser(table);
            UserViewModel User = dal.DataSetToUser(table);

            return User;
        }


        public int GetCurrentUserLocation(int UserId)
        {
            SqlCommand cmd = new SqlCommand("SELECT Location_ID FROM [User] WHERE ID = @User_ID", GetCon());
            cmd.Parameters.AddWithValue("User_ID", UserId);

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            table.Clear();
            adapt.Fill(table);

            CloseConnectionToDB();

            int location = Convert.ToInt32(table.Rows[0][0]);
            return location;
        }
    }
}
