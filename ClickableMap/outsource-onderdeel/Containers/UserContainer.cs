using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using outsource_onderdeel.Models.ViewModels;
using outsource_onderdeel.Interfaces;

namespace outsource_onderdeel.Containers
{
    public class UserContainer : IUser
    {
        private IUser Context;

        public UserContainer(IUser context)
        {
            Context = context;
        }

        public UserViewModel InsertUserLocationByID(int UId, int LId)
        {
            return Context.InsertUserLocationByID(UId, LId);
        }

        public int GetCurrentUserLocation(int UserId)
        {
            return Context.GetCurrentUserLocation(UserId);
        }
    }
}
