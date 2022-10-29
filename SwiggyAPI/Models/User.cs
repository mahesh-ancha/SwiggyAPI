using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAPI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set;  }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public DateTime MemberSince { get; set; }
    }
}
