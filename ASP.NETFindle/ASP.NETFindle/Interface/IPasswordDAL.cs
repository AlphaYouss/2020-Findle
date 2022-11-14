using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETFindle.Interface
{
    public interface IPasswordDAL
    {
        public string GetPasswordhash(string email);
        public string GetPasswordsalt(string email);
    }
}
