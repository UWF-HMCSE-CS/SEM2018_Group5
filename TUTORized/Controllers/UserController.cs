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

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("registerUser")]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            return Ok(await _userService.RegisterUser(user));
        }

        [HttpPost("loginUser")]
        public async Task<IActionResult> LoginUser([FromBody] User user)
        {
            //Takes the user entered email and password and returns the User obj
            User result = await _userService.LoginUser(user.Email, user.Password);

            //Compare the email and password from the entered user with the returned user obj email and password
            if (result == null)
            {
                return BadRequest("Invalid Email or Password");
            }

            if (user.Password.Equals(result.Password))
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<Appointment>), 200)]
        public async Task<IActionResult> GetListOfUserAppointments()
        {
            var listOfAppointments = await _userService.GetEntireUserAppointmentListAsync();
            var test = listOfAppointments;
            return Ok(test);
        }

        [HttpGet("getListOfUsersWorkedWith")]
        [ProducesResponseType(typeof(IList<User>), 200)]
        public async Task<IActionResult> GetListOfUsersWorkedWithAsync()
        {
            var listOfUsersWorkedWith = await _userService.GetListOfUsersWorkedWithAsync();
            var test = listOfUsersWorkedWith;
            return Ok(test);
        }
    }
}