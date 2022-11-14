using ASP.NETFindle.Container;
using ASP.NETFindle.DataBase;
using ASP.NETFindle.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETFindle.Controllers
{
    public class LoginController : Controller
    {
        UserContainer userContainer;

        public LoginController()
        {
            userContainer = new UserContainer(new UserDAL());
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (login.Password == null)
            {
                //Show wrong password error
                ModelState.AddModelError("Password", "Please enter a valid password!");
                return View("Index");
            }
            else if (!userContainer.UserExists(login.Email))
            {
                //Show wrong email error
                ModelState.AddModelError("Email", "This Email doesn't exist!");
                return View("Index");
            }
            else if (userContainer.PasswordIsCorrect(login.Email, login.Password))
            {
                User user = new User();

                //Get user data when password is correct and user exists
                user = userContainer.LoginUser(login.Email, login.Password, userContainer.PasswordIsCorrect(login.Email, login.Password));
                user.Findable = false;

                //Session variables
                HttpContext.Session.SetString("Id", user.Id.ToString());
                HttpContext.Session.SetString("FirstName", user.Firstname);
                HttpContext.Session.SetString("location_Id", user.location_Id.ToString());
                HttpContext.Session.SetString("LastName", user.Lastname);
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetString("Profile", user.Profile);
                HttpContext.Session.SetString("UserFunction", user.UserFunction);
                HttpContext.Session.SetString("Findable", user.Findable.ToString());

                userContainer.SetFindable(false, user.Id);

                //Go to homepage of user
                return RedirectToAction("Index", "User", user);
            }
            else
            {
                //Show wrong password error
                ModelState.AddModelError("Password", "Wrong password!");
                return View("Index");
            }
        }
    }
}