using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using outsource_onderdeel.Containers;
using outsource_onderdeel.Models.ViewModels;
using outsource_onderdeel.Interfaces;
using outsource_onderdeel.DAL;

namespace outsource_onderdeel.Controllers
{
    public class MapController : Controller
    {
        private readonly UserContainer userRepo;
        private readonly LocationContainer locationRepo;

        public MapController()
        {
            
            IUser IUContext = new UserDAL();
            ILocation ILContext = new LocationDAL();
            userRepo = new UserContainer(IUContext);
            locationRepo = new LocationContainer(ILContext);
        }

        public IActionResult Index()
        {
            int uvm;
            uvm = userRepo.GetCurrentUserLocation(1);
            LocationViewModel lvm = new LocationViewModel();
            
            lvm = locationRepo.GetByID(uvm);
            return View(lvm);
        }



        [HttpGet]
        public IActionResult RoomChange(int id)
        {
            UserViewModel vm = new UserViewModel();
            vm = userRepo.InsertUserLocationByID(1, id);
            return View(vm);
        }
    }
}