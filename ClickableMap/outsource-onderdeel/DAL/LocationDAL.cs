using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using outsource_onderdeel.Models.ViewModels;
using outsource_onderdeel.Interfaces;

namespace outsource_onderdeel.DAL
{
    public class LocationDAL : Databasehandler, ILocation
    {
        MapDAL dal = new MapDAL();

        public LocationViewModel GetByID(int LId)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [Location] WHERE ID = @Location_ID", GetCon());
            command.Parameters.AddWithValue("Location_ID", LId);

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            table.Clear();
            adapt.Fill(table);

            CloseConnectionToDB();

            LocationViewModel result = dal.DataSetToLocation(table);

            return result;
        }
    }
}
