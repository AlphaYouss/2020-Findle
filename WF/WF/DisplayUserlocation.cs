using System;
using System.Drawing;
using System.Windows.Forms;

namespace WPFFINDLE_BAS
{
    public partial class DisplayUserlocation : Form
    {
        private User user { get; set; }
        private Location location { get; set; }

        private void TSMISearch_Click(object sender, EventArgs e)
        {
            Hide();

            Search search = new Search();
            search.SetUser(user);
            search.ShowDialog();

            Close();
        }

        private void TSMISetlocation_Click(object sender, EventArgs e)
        {
            Hide();

            SetUserLocation setUserLocation = new SetUserLocation();
            setUserLocation.SetUser(user);
            setUserLocation.ShowDialog();

            Close();
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
                lblDescription.Text = "";
                lblRoom.Text = "";

                btnUnset.Visible = false;
                btnShow.Visible = false;
                btnHide.Visible = false;

                pbRoom.Image = null;
            }
        }

        private void TSMILogout_Click(object sender, EventArgs e)
        {
            Hide();

            Login login = new Login();
            login.ShowDialog();

            Close();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            user.SetUserFindable(false);

            lblMessage.Text = "Location is hidden!";
            btnShow.Visible = true;
            btnHide.Visible = false;
            
            pbRoom.Image = Image.FromFile("Resources/Map/Verdieping" + location.floor + "Grey.png");   
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            user.SetUserFindable(true);

            lblMessage.Text = "Location is visible!";
            btnShow.Visible = false;
            btnHide.Visible = true;

            pbRoom.Image = Image.FromFile("Resources/Map/Verdieping" + location.floor + ".png");
        }

        private void btnUnset_Click(object sender, EventArgs e)
        {
            user.SetUserLocation();
            lblMessage.Text = "Location unset!";

            lblDescription.Text = "";
            lblRoom.Text = "";

            btnUnset.Visible = false;
            btnShow.Visible = false;
            btnHide.Visible = false;

            pbRoom.Image = null;
        }

        public void DisplayLocation(bool mylocation)
        {
            InitializeComponent();

            string actualFloor = "";
            switch (location.floor)
            {
                default:
                    break;
                case "0":
                    actualFloor = "ground floor";
                    break;
                case "1":
                    actualFloor = "first floor";
                    break;
                case "2":
                    actualFloor = "second floor";
                    break;
                case "3":
                    actualFloor = "third floor";
                    break;
            }

            if (mylocation == true)
            {
                if (user.findable == false)
                {
                    lblMessage.Text = "Location is hidden!";
                    btnHide.Visible = false;

                    pbRoom.Image = Image.FromFile("Resources/Map/Verdieping" + location.floor + "Grey.png");
                }
                else
                {
                    lblMessage.Text = "Location is visible!";
                    btnShow.Visible = false;

                    pbRoom.Image = Image.FromFile("Resources/Map/Verdieping" + location.floor + ".png");
                }

                lblDescription.Text = "You're at building " + location.building + ", on the " + actualFloor + ".";
                lblRoom.Text = "Room: " + location.floor + "." + location.room;                                         
            }
            else
            {
                btnShow.Visible = false;
                btnHide.Visible = false;
                btnUnset.Visible = false;

                lblDescription.Text = "He/she can be found in building " + location.building + "," + Environment.NewLine + "on the "+ actualFloor + ".";
                lblRoom.Text = "Room: " + location.floor + "." + location.room;

                pbRoom.Image = Image.FromFile("Resources/Map/Verdieping" + location.floor + ".png");
            }
        }

        internal void SetLocation(Location location)
        {
            this.location = location;
        }

        internal void SetUser(User user)
        {
            this.user = user;
        }
    }
}