using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Users
{
    public class LoginUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
