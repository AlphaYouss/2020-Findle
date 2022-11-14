using System;
using System.Windows.Forms;

namespace WPFFINDLE_BAS
{
    public partial class Login : Form
    {
        private Databasehandler databasehandler { get; set; } = new Databasehandler();
        private Validater validater { get; set; } = new Validater();
        private bool validDetails { get; set; } = false;
        private bool userExists { get; set; } = false;
        private bool goodCombination { get; set; } = false;

        public Login()
        {
            InitializeComponent();

            if (!databasehandler.TestConnection())
            {
                lblMessage.Text = lblMessage.Text + "Database offline, contact us!";
            }      
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            validDetails = false;
            userExists = false;
            goodCombination = false;

            CheckInput();
            login();
        }

        private void login()
        {
            if (validDetails)
            {
                User user = new User();

                CheckIfUserExists(user, txtMail.Text);
                if (userExists)
                {
                    CheckUserData(user, txtMail.Text, txtPassword.Text);
                    if (goodCombination)
                    {
                        user.GetUserData(txtMail.Text);

                        Hide();

                        Search search = new Search();
                        search.SetUser(user);
                        search.ShowDialog();

                        Close();
                    }
                }
            }
        }

        private void CheckInput()
        {
            if (!validater.ValidateEmail(txtMail.Text) || !validater.ValidatePassword(txtPassword.Text))
            {
                lblMessage.Text = "Enter a valid email and password.";
            }
            else
            {
                validDetails = true;
            }
        }

        private void CheckIfUserExists(User user, string email)
        {
            if (!user.CheckExistance(email))
            {
                lblMessage.Text = "There is no user with that email.";
            }
            else
            {
                userExists = true;
            }   
        }

        private void CheckUserData(User user, string email, string password)
        {     
            if (!user.LoginUser(txtMail.Text, txtPassword.Text))
            {
                lblMessage.Text = "Wrong password!";
            }
            else
            {
                goodCombination = true;
            }
        }
    }
}