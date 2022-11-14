using System;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP.NETFindle.Models;
using ASP.NETFindle.Container;
using ASP.NETFindle.DataBase;

namespace ASP.NETFindle.Controllers
{
    public class UserController : Controller
    {
        HistoryContainer historyContainer;
        UserContainer userContainer;
        LocationContainer locationContainer;

        static User currentUser;

        public UserController()
        {
            userContainer = new UserContainer(new UserDAL());
            historyContainer = new HistoryContainer(new HistoryDAL());
            locationContainer = new LocationContainer(new LocationDAL());
        }

        [HttpGet]
        public IActionResult Index(User user)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                currentUser = user;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult SearchUser(Search search)
        {
            if (search.Name == null)
            {
                search.Name = "";
            }
            search.Name = search.Name.Trim();

            DataTable table = userContainer.SearchUser(Convert.ToInt32(HttpContext.Session.GetString("Id")), search.Name);

            return PartialView("../Partials/_SearchResults", table);
        }

        [HttpPost]
        public ActionResult DisplayUser(int targetId)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                User user = new User();
                user = userContainer.GetUser(targetId);

                ViewData["targetUser"] = user;

                Location location = locationContainer.GetLocation(user.location_Id);
                DataTable table = locationContainer.GetFloor(Convert.ToInt32(location.Floor));

                ViewData["currentUser"] = user;
                ViewData["floor"] = location.Floor;
                ViewData["room"] = location.Room;

                return View("SearchLocation", table);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult PersonalDetails()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                ViewData["currentUser"] = currentUser;
                return View(currentUser);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult GetChangePassword()
        {
            return PartialView("../Partials/_Password");
        }

        public IActionResult ChangePassword(string password, string passwordRepeat)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                ViewData["currentUser"] = currentUser;

                if (password == passwordRepeat)
                {
                    if (ValidatePassword(password))
                    {
                        userContainer.EditUser(currentUser.Id, password);
                    }
                    else
                    {
                        ModelState.AddModelError("password", "The password needs to be 8+ characters and containing at least 1 number and 1 caps!");
                    }
                }
                else
                {
                    ModelState.AddModelError("password", "Passwords are not the same!");
                }
                return View("PersonalDetails");
            }
            else
            {
                return RedirectToAction("PersonalDetails");
            }
        }

        public bool ValidatePassword(string password)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            bool isValid = regex.IsMatch(password.Trim());

            if (!isValid)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public ActionResult GetHistories()
        {
            DataTable table = historyContainer.GetHistories(Convert.ToInt32(HttpContext.Session.GetString("Id")));

            return PartialView("../Partials/_SearchHistory", table);
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();

            userContainer.SetFindable(false, currentUser.Id);

            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult GetFloor(int floorid)
        {
            DataTable table = locationContainer.GetFloor(floorid);

            if(HttpContext.Session.GetString("Id") != null)
            {
                ViewData["selectedFloor"] = floorid;
                return View("SetLocation", table);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Findable()
        {
            HttpContext.Session.Remove("Findable");
            HttpContext.Session.SetString("Findable", userContainer.GetFindable(currentUser.Id).ToString());

            return PartialView("../Partials/_Findable", currentUser);
        }

        [HttpPost]
        public IActionResult Findable(bool findable)
        {
            userContainer.SetFindable(findable, currentUser.Id);

            HttpContext.Session.Remove("Findable");
            HttpContext.Session.SetString("Findable", userContainer.GetFindable(currentUser.Id).ToString());

            return View("Home");
        }

        [HttpGet]
        public IActionResult ChangeLocation(int id)
        {
            currentUser = userContainer.UpdateUserLocation(currentUser.Id, id);
            return View("GetFloor");
        }
    }
}