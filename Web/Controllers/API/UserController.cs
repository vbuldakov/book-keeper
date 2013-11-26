using Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.API
{
    [Authorize]
    public class UserController : ApiController
    {
        private readonly IUsersService _userService;

        public UserController(IUsersService userService)
        {
            _userService = userService;
        }

        // GET api/user
        public UserDTO Get()
        {
            return _userService.GetCurrentUser();
        }

        [HttpPost]
        public void Logout()
        {
            _userService.Logout();
        }
    }
}
