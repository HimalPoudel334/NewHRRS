using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRRS.Models;

namespace HRRS.Dto.Login
{
    public class LoginDto
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class LoggedInUser
    {
        public long userId { get; set; }
        public string username { get; set; }
        public string userRole { get; set; }
        public int healthFacilityId { get; set; }

    }

    public class AuthResponseDto
    {
        public LoggedInUser user { get; set; }
        public string token { get; set; }
    }
}