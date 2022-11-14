using System.Text.RegularExpressions;

namespace WPFFINDLE_BAS
{
    class Validater
    {
        public bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            bool isValid = regex.IsMatch(email.Trim());

            if (!isValid)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidatePassword(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
