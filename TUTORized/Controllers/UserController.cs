using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TUTORized.Services.Abstract;

namespace TUTORized.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public void RegisterUser(string email, string password, string firstName, string lastName, string role)
        {
            RegisterUser(email, password, firstName, lastName, role);
        }
    }
}
