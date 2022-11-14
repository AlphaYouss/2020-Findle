using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WPFFINDLE_BAS
{
    public partial class SetUserLocation : Form
    {
        private User user { get; set; }
        private Databasehandler databasehandler { get; set; } = new Databasehandler();
        private SqlCommand command { get; set; } = new SqlCommand();
        private List<Location> allLocations { get; set; } = new List<Location>();
        private List<Location> selectedFloorLocations { get; set; } = new List<Location>();

        public SetUserLocation()
        {
            InitializeComponent();
            GetAllLocations();

            lbLevel.Items.Add("Ground floor");
            lbLevel.Items.Add("First floor");
            lbLevel.Items.Add("Second floor");
            lbLevel.Items.Add("Third floor");
        }

        public void GetAllLocations()
        {
            command = new SqlCommand("SELECT * FROM [LOCATION] WHERE BUILDING = 'P8'", databasehandler.GetCon());
            databasehandler.OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(databasehandler.table);

            databasehandler.CloseConnectionToDB();

            foreach (DataRow row in databasehandler.table.Rows)
            {
                Location foundLocation = new Location();
                foundLocation.SetLocation(Convert.ToInt32(row["ID"]), Convert.ToString(row["Building"]), Convert.ToString(row["Floor"]), Convert.ToString(row["Room"]));
                
                allLocations.Add(foundLocation);
            }
        }
        
        private void TSMISearch_Click(object sender, EventArgs e)
        {
            Hide();

            Search search = new Search();
            search.SetUser(user);
            search.ShowDialog();

            Close();
        }

        private void TSMILogout_Click(object sender, EventArgs e)
        {
            Hide();

            Login login = new Login();
            login.ShowDialog();

            Close();
        }

        private void lbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSetLocation.Visible = false;
            lbRooms.Items.Clear();

            foreach (Location location in allLocations)
            {
                if (location.floor.StartsWith(lbLevel.SelectedIndex.ToString()))
                {
                    lbRooms.Items.Add(location.room);
                    selectedFloorLocations.Add(location);
                }
            }

            if (lbLevel.SelectedIndex >= 0 && lbLevel.SelectedIndex <= 3)
            {
                LocationPicture.Image = Image.FromFile("Resources/Map/Verdieping" + lbLevel.SelectedIndex + ".png");
            }
            else
            {
                LocationPicture.Image = null;
            }
        }

        private void btnSetLocation_Click(object sender, EventArgs e)
        {
            SetUserCurrentLocation();

            lbRooms.SelectedIndex = -1;
            lbLevel.SelectedIndex = -1;
            btnSetLocation.Visible = false;
        }

        private void SetUserCurrentLocation()
        {
            command = new SqlCommand("UPDATE [USER] SET Location_ID = @location_ID WHERE Email = @email", databasehandler.GetCon());

            command.Parameters.AddWithValue("Email", user.email);
            command.Parameters.AddWithValue("location_ID", selectedFloorLocations[lbRooms.SelectedIndex].id);

            databasehandler.OpenConnectionToDB();
            command.ExecuteNonQuery();
            databasehandler.CloseConnectionToDB();

            lblMessage.Text = "Location updated!";

            user.SetUserLocation(selectedFloorLocations[lbRooms.SelectedIndex]);
        }

        private void lbRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbRooms.SelectedIndex < 0)
                btnSetLocation.Visible = false;
            else
                btnSetLocation.Visible = true;
        }

        private void TSMIMylocation_Click(object sender, EventArgs e)
        {
            if (user.myLocation.building != null)
            {
                Hide();

                DisplayUserlocation displayUserlocation = new DisplayUserlocation();
                displayUserlocation.SetLocation(user.myLocation);
                displayUserlocation.SetUser(user);
                displayUserlocation.DisplayLocation(true);

                displayUserlocation.ShowDialog();
                Close();
            }
            else
            {
                lblMessage.Text = "You haven't picked your location!";
            }
        }

        internal void SetUser(User user)
        {
            this.user = user;
        }
    }
}