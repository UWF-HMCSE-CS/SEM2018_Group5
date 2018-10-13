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
        private readonly IUserRepository _userRepository;

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
        /// <summary>
        /// checks to see if user email and user password matches email and password in the db and lets them log in
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        //  public async Task<User> LoginUserAsync(string userEmail, string userPassword)
        public void LoginUser(string userEmail, string userPassword)
        {
            //Gets the email and password from the database
            User fetchDbUser = (User)_userService.LoginUser(userEmail, userPassword);

            //Checks the entered email with the email from the database
            if (userEmail.Equals(fetchDbUser.Email))
            {
                //Checks the entered password with the password from the database
                if (userPassword.Equals(fetchDbUser.Password))
                {
                    Ok();
                }

                else
                {
                    BadRequest();
                }
            }

            else
            {
                BadRequest();
            }
        }

    }
}
