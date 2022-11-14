using System;
using System.Data;
using ASP.NETFindle.Interface;
using ASP.NETFindle.Models;
using Microsoft.Data.SqlClient;

namespace ASP.NETFindle.DataBase
{
    public class LocationDAL : Databasehandler, ILocationDAL
    {
        public DataTable GetFloor(int floorid)
        {
            DataTable table = new DataTable();
            
            command = new SqlCommand("SELECT CONCAT(Location.Floor, '.', Location.Room) as Roomnumber, CONCAT('area-PK', Location.ID) as ID, [Location].[Shape], [Location].[Coords] FROM Location WHERE[Location].[Floor] = @CurrentFloor", GetCon());
            command.Parameters.AddWithValue("CurrentFloor", floorid);

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(table);

            CloseConnectionToDB();

            return table;
        }

        public int GetFloorByLocation(int locationID)
        {
            DataTable table = new DataTable();

            command = new SqlCommand("SELECT FLOOR FROM Location WHERE ID = @locationID", GetCon());
            command.Parameters.AddWithValue("locationID", locationID);

            OpenConnectionToDB();
            int floor = Convert.ToInt32(command.ExecuteScalar());

            CloseConnectionToDB();

            return floor;
        }

        public Location GetLocation(int locationID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [Location] WHERE ID = @Location_ID", GetCon());
            command.Parameters.AddWithValue("Location_ID", locationID);

            DataTable table = new DataTable();

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(table);

            CloseConnectionToDB();

            Location result = new Location();

            result.Id = Convert.ToInt32(table.Rows[0][0]);
            result.Building = table.Rows[0][1].ToString();
            result.Floor = table.Rows[0][2].ToString();
            result.Room = table.Rows[0][3].ToString();

            return result;
        }

        public void LocationSet(int userId, int locationId)
        {
            command = new SqlCommand("UPDATE [USER] SET Location_ID = @Location_ID WHERE ID = @userId", GetCon());

            command.Parameters.AddWithValue("userId", userId);
            command.Parameters.AddWithValue("Location_ID", locationId);

            OpenConnectionToDB();
            command.ExecuteNonQuery();
            CloseConnectionToDB();
        }
    }
}