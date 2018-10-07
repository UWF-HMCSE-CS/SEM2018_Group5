using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Models;
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
File Name: UserService.cs 
    This class provides the logic for all User actions.
*/

namespace TUTORized.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Creates a default User object with no given parameters (each initialized to "" (the empty string))
        /// </summary>
        /// <returns>User</returns>
        public User CreateUserObject()
        {
            var newUserObject = new User();
            return newUserObject;
        }

        /// <summary>
        /// Creates a User object with all instance variables given except Id
        /// Primarily used when Registering a new User, because the DataBase will issue an Id
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="role"></param>
        /// <returns>User</returns>
        public User CreateUserObject(string email, string password, string firstName, string lastName, string role)
        {
            var newUserObject = new User(email, password, firstName, lastName, role);
            return newUserObject;
        }

        /// <summary>
        /// Creates a User object with all instance variables
        /// Primarily used when creating a user with information retrieved from the DataBase
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public User CreateUserObject(string id, string email, string password, string firstName, string lastName, string role)
        {
            var newUserObject = new User(id, email, password, firstName, lastName, role);
            return newUserObject;
        }

        /// <summary>
        /// Used to Register a new User by creating a new user object and saving the 
        /// information to the Database
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="role"></param>
        public void RegisterUser(string email, string password, string firstName, string lastName, string role)
        {
            var user = CreateUserObject(email, password, firstName, lastName, role);
            _userRepository.UserProfileCreateAsync(user);
        }
    }
}
