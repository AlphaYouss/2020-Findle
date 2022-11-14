using System.Data;
using ASP.NETFindle.Models;

namespace ASP.NETFindle.Interface
{
    /// <summary>
    /// Class die dit implement Moet alle functies ook implementen. Soort contract.
    /// </summary>
    public interface IUserDAL
    {
        User UserLogin(string email, string password, bool isPasswordCorrect);
        DataTable UserSearch(int UserID, string name);

        User UserGet(int id);

        bool CheckUserExists(string email);
        bool CheckPasswordIsCorrect(string email, string password);

        void EditUser(int userID, string password);
        void SetUserFindable(bool findable, int userID);
        bool GetUserFindable(int userID);

        User UpdateUserLocation(int userID, int locationID);
        int GetUserLocation(int userID);
    }
}