using System.Data;
using ASP.NETFindle.Models;
using ASP.NETFindle.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Check_If_User_Exists()
        {
            bool result;

            UserMockDAL mockDAL = new UserMockDAL();
            UserContainer uc = new UserContainer(mockDAL);
            mockDAL.returnValue = false;

            result = uc.UserExists("hoi");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Check_If_Returns_Email_And_Password()
        {
            bool result;

            UserMockDAL mockDAL = new UserMockDAL();
            UserContainer uc = new UserContainer(mockDAL);
            mockDAL.returnValue = false;

            result = uc.PasswordIsCorrect("", "");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Search_User()
        {
            UserMockDAL mockDAL = new UserMockDAL();
            UserContainer uc = new UserContainer(mockDAL);
            DataTable dt = dt = uc.SearchUser(0, "");

            Assert.IsNotNull(dt);
        }

        [TestMethod]
        public void Get_Findable()
        {
            bool result;

            UserMockDAL mockDAL = new UserMockDAL();
            UserContainer uc = new UserContainer(mockDAL);

            result = uc.GetFindable(0);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Set_Findable()
        {
            User user = new User();
            UserMockDAL mockDAL = new UserMockDAL();
            UserContainer uc = new UserContainer(mockDAL);

            uc.SetFindable(false, 0);

            Assert.IsFalse(user.Findable);
        }

        [TestMethod]
        public void See_If_Returns_User()
        {
            string result;

            User user = new User();
            UserMockDAL mockDAL = new UserMockDAL();
            UserContainer uc = new UserContainer(mockDAL);

            result = uc.GetUser(0).Email;

            Assert.AreEqual("Yoda", result);
        }

        [TestMethod]
        public void See_If_Returns_Email()
        {
            string result;

            UserMockDAL mockDAL = new UserMockDAL();
            UserContainer uc = new UserContainer(mockDAL);

            result = uc.GetUser(0).Email;

            Assert.AreEqual("Yoda", result);
        }

        //[TestMethod]
        //public void See_if_Returns_Table()
        //{
        //    LocationMockDAL lmd = new LocationMockDAL();
        //    LocationContainer lc = new LocationContainer(lmd);

        //    var result = lc.GetAllLocations();
        //    Assert.IsNotNull(result);
        //}

        [TestMethod]
        public void Set_User_Location()
        {
            LocationMockDAL lmd = new LocationMockDAL();
            LocationContainer lc = new LocationContainer(lmd);

            lc.SetCurrentLocation(1, 1);

            Assert.AreEqual("1e", lmd.location.Floor);
            Assert.AreEqual("P8", lmd.location.Building);
            Assert.AreEqual(1, lmd.location.Id);
            Assert.AreEqual("Auditorium", lmd.location.Room);
        }
    }
}