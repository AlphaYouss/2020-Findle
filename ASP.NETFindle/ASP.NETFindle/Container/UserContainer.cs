using System.Data;
using ASP.NETFindle.Interface;
using ASP.NETFindle.Models;

namespace ASP.NETFindle.Container
{
    public class UserContainer
    {
        IUserDAL userDAL;

        public UserContainer(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }

        public void EditUser(int userID, string password)
        {
            userDAL.EditUser(userID, password);
        }

        public DataTable SearchUser(int userID, string name)
        {
            return userDAL.UserSearch(userID, name);
        }

        public User GetUser(int id)
        {
            return userDAL.UserGet(id);
        }

        public User LoginUser(string email, string password, bool isPasswordCorrect)
        {
            return userDAL.UserLogin(email, password, isPasswordCorrect);
        }

        public bool PasswordIsCorrect(string email, string password)
        {
            return userDAL.CheckPasswordIsCorrect(email, password);
        }

        public void SetFindable(bool findable, int userID)
        {
            userDAL.SetUserFindable(findable, userID);
        }

        public bool GetFindable(int userID)
        {
            return userDAL.GetUserFindable(userID);
        }

        public bool UserExists(string email)
        {
            return userDAL.CheckUserExists(email);
        }

        public User UpdateUserLocation(int userID, int locationID)
        {
            return userDAL.UpdateUserLocation(userID, locationID);
        }

        public int GetUserLocation(int userID)
        {
            return userDAL.GetUserLocation(userID);
        }
    }
}