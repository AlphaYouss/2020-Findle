using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASP.NETFindle.DataBase;
using System.Data;

namespace ASP.NETFindle.Models
{
    public class User
    {
        public List<SearchHistory> searchHistories { get; set; }

        public int location_Id { get; set; }

        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [MaxLength(320, ErrorMessage = "Teveel Karakters") ]

        [EmailAddress]
        public string Email { get; set; }
        public string Profile { get; set; }
        public string UserFunction { get; set; }
        public bool Findable { get; set; }
    }
}