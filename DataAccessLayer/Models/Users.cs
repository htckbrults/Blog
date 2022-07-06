using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Summary { get; set; }
        public string Explanation { get; set; }
        public string Phone { get; set; }
        public string AvatarImages { get; set; }
        public List<Blogs> Blogs { get; set; }
    }
}
