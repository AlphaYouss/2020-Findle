using System;
using System.Data.SqlClient;

namespace WPFFINDLE_BAS
{
    class Location
    {
        private Databasehandler databasehandler { get; set; } = new Databasehandler();
        private SqlCommand command { get; set; } = new SqlCommand();
        public int id { get; private set; }
        public string building { get; private set; }
        public string floor { get; private set; }
        public string room { get; private set; }

        public void GetUserLocation(string email)
        {
            int locationID = 0;

            command = new SqlCommand("SELECT Location_ID FROM [User] WHERE email = @email", databasehandler.GetCon());
            command.Parameters.AddWithValue("email", email);

            databasehandler.OpenConnectionToDB();
            if (Convert.ToString(command.ExecuteScalar()) != "")
            {
                locationID = Convert.ToInt32(command.ExecuteScalar());
                databasehandler.CloseConnectionToDB();
                command = new SqlCommand();

                GetLocationDetails(locationID);
            }
            else
            {
                databasehandler.CloseConnectionToDB();
            }
        }

        public void GetLocationDetails(int LocationID)
        {
            command = new SqlCommand("SELECT * FROM [Location] WHERE ID = @id", databasehandler.GetCon());
            command.Parameters.AddWithValue("id", LocationID);

            databasehandler.OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(databasehandler.table);

            databasehandler.CloseConnectionToDB();
            command = new SqlCommand();

            SetLocation(
            Convert.ToInt32(databasehandler.table.Rows[0]["ID"]),
            Convert.ToString(databasehandler.table.Rows[0]["Building"]),
            Convert.ToString(databasehandler.table.Rows[0]["Floor"]),
            Convert.ToString(databasehandler.table.Rows[0]["Room"]));

            databasehandler.ClearTable();
        }

        public void SetLocation(int id,string building, string floor, string room)
        {
            this.id = id;
            this.building = building;
            this.floor = floor;
            this.room = room;
        }
    }
}
