using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace outsource_onderdeel.Models.ViewModels
{
    public class LocationViewModel
    {
        public int ID { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
    }
}
