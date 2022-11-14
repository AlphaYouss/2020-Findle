using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using outsource_onderdeel.Models.ViewModels;
using outsource_onderdeel.Interfaces;
using outsource_onderdeel.DAL;

namespace outsource_onderdeel.Containers
{
    public class LocationContainer : ILocation
    {
        ILocation Context;

        

        public LocationContainer(ILocation context)
        {
            Context = context;
        }

        public LocationViewModel GetByID(int LocationId)
        {
            //return DAL.GetByID(LocationId);
            return Context.GetByID(LocationId);
        }
    }
}
