using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace outsource_onderdeel.Models.ViewModels
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public int Location_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Profile { get; set; }
        public string UserFunction { get; set; }
        public bool Findable { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
