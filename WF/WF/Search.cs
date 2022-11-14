using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WPFFINDLE_BAS
{
    public partial class Search : Form
    {
        private User user { get; set; }
        private Databasehandler databasehandler { get; set; } = new Databasehandler();
        private SqlCommand command { get; set; } = new SqlCommand();
        private List<User> usersFound { get; set; } = new List<User>();
        private int selectedCurrentItem { get; set; }

        public Search()
        {
            InitializeComponent();
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
                displayUserlocation.SetUser(user);
                displayUserlocation.SetLocation(user.myLocation);
                displayUserlocation.DisplayLocation(true);

                displayUserlocation.ShowDialog();
                Close();
            }
            else
            {
                lblMessage.Text = "You haven't picked your location!";
            }
        }

        private void TSMILogout_Click(object sender, EventArgs e)
        {
            Hide();

            Login login = new Login();
            login.ShowDialog();

            Close();
        }

        private void Searchtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnFind.Visible = false;
            usersFound.Clear();

            if (txtSearch.Text != "")
            {
                lblMessage.Text = "";

                SearchUser(txtSearch.Text);
                DisplayUsers();
            }
            else
            {
                DisplayUsers();
            }
        }

        public void SearchUser(string name)
        {

            command = new SqlCommand("SELECT * FROM [USER] WHERE Firstname LIKE '%' + @input + '%' OR Lastname LIKE '%' + @input + '%'", databasehandler.GetCon());
            command.Parameters.AddWithValue("input", name);
            databasehandler.OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(databasehandler.table);

            databasehandler.CloseConnectionToDB();
            command = new SqlCommand();

            SaveUsers();
        }

        private void SaveUsers()
        {
            foreach (DataRow row in databasehandler.table.Rows)
            {
                if (Convert.ToInt32(row["ID"]) != user.id)
                {
                    User foundUser = new User();
                    foundUser.SetUserDetails(Convert.ToInt32(row["ID"]), Convert.ToString(row["Firstname"]), Convert.ToString(row["Lastname"]), Convert.ToString(row["Email"]), Convert.ToString(row["Profile"]), Convert.ToString(row["UserFunction"]), Convert.ToBoolean(row["Findable"]));
                    foundUser.FindMyLocation();

                    usersFound.Add(foundUser);
                }
            }
            databasehandler.ClearTable();
        }

        private void DisplayUsers()
        {
            lbUsers.Items.Clear();

            foreach (User user in usersFound)
            {
                string name = "(" + user.function + ") "+ user.firstname + " " + user.lastname;
                lbUsers.Items.Add(name);
            }

            if (lbUsers.Items.Count == 0)
            {
                lblMessage.Text = "No user found.";
            }
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCurrentItem = lbUsers.SelectedIndex;

            if (selectedCurrentItem < 0)
                btnFind.Visible = false;
            else
                btnFind.Visible = true;
        }

        public void btnFind_Click(object sender, EventArgs e)
        {
            selectedCurrentItem = lbUsers.SelectedIndex;

            if (usersFound[selectedCurrentItem].myLocation.id == 0)
            {
                lblMessage.Text = "The user has no location.";
            }
            else if(usersFound[selectedCurrentItem].findable == false)
            {
                lblMessage.Text = "The user doesn't want to get found.";
            }
            else
            {
                SearchHistory currentSearch = new SearchHistory();
                currentSearch.SetSearchHistory(user.id, usersFound[selectedCurrentItem].id);

                user.SetSearchhistory(currentSearch);

                Hide();

                DisplayUserlocation displayUserlocation = new DisplayUserlocation();
                displayUserlocation.SetUser(user);
                displayUserlocation.SetLocation(usersFound[selectedCurrentItem].myLocation);
                displayUserlocation.DisplayLocation(false);
                displayUserlocation.ShowDialog();

                Close();
            }
        }

        internal void SetUser(User user)
        {
            this.user = user;
        }
    }
}