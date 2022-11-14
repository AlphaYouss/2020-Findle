using System;
using System.Collections.Generic;
using System.Data;
using ASP.NETFindle.Interface;
using ASP.NETFindle.Models;

namespace UserTest
{
    public class UserMockDAL : IUserDAL
    {
        List<string> user = new List<string>();
        List<bool> findable = new List<bool>();
        List<User> users = new List<User>
        {
            new User
            {
                Email = "Yoda"
            }
        };
        User currentUser = new User();

        public bool? returnValue = null;

        public bool CheckPasswordIsCorrect(string email, string password)
        {
            if(returnValue == null)
            {
                throw new NullReferenceException("Invalid use of stubcode.");
            }
            return returnValue.Value;
        }

        public bool CheckUserExists(string email)
        {
            if (returnValue == null)
            {
                throw new NullReferenceException("Invalid use of stubcode.");
            }

            user.Add("hoi");

            if (user.Contains(email))
            {
                returnValue = true;
            }
            return returnValue.Value;
        }

        public void EditUser(int userID, string password)
        {
            throw new NotImplementedException();
        }

        public bool GetUserFindable(int userID)
        {
            findable.Add(false);

            if(findable[userID] == false)
            {
                return false;
            }
            return true;
        }

        public void SetUserFindable(bool findable, int userID)
        {
            currentUser.Findable = findable;
        }

        public User UserGet(int id)
        {
            return users[id];
        }

        public User UserLogin(string email, string password, bool isPasswordCorrect)
        {
            throw new NotImplementedException();
        }

        public DataTable UserSearch(int UserID, string name)
        {
            return new DataTable();
        }

        public User UpdateUserLocation(int userID, int locationID)
        {
            throw new NotImplementedException();
        }

        public int GetUserLocation(int userID)
        {
            throw new NotImplementedException();
        }
    }
}