using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using TUTORized.Models;
using TUTORized.Repository;
using TUTORized.Repository.Abstract;
using TUTORized.Services.Abstract;

/**
TUTORized is a web application designed for use in 
schools. Students can coordinate with Tutors to set 
up tutoring sessions. Students and Tutors are also 
able to message each other, as well as share resources
with each other.
@author Timothy McWatters
@author Keenal Shah
@author Wesley Easton
@author Wenwen Xu
@version 1.0
CEN4053    "TUTORized" SEM- Group 5's class project
File Name: UserController.cs 
    This class maps the interface to the User actions.
*/

namespace TUTORized.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController()
        {
               
        }
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

       [HttpPost("registerUser")]
        public void RegisterUser([FromBody] User user)
        {
            _userService.RegisterUser(user);
            

        }

        [HttpPost("loginUser")]
        public async Task<IActionResult> LoginUserX(string userEmail, string userPassword)
        {
            //Takes the user entered email and password and returns the User obj
            User x = await _userService.LoginUser(userEmail, userPassword);

            //Compare the email and password from the entered user with the returned user obj email and password
            if (string.IsNullOrEmpty(x.Id))
            {
                return BadRequest();
                //Console.WriteLine("it matches");
            }

            if (userPassword.Equals(x.Password))
            {
                return Ok();
              //  Console.WriteLine("it doesnt match");
                
            }

            return BadRequest();
                
        }
    }
}
