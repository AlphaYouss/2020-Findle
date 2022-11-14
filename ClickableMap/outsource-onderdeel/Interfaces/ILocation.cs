using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using outsource_onderdeel.Models.ViewModels;

namespace outsource_onderdeel.Interfaces
{
    public interface ILocation
    {
        public LocationViewModel GetByID(int LocationId);
    }
}
