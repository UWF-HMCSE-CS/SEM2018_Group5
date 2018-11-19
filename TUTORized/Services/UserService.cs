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
        /// Used to Register a new User by creating a new user object and saving the 
        /// information to the Database
        /// </summary>
        /// <param name="user"></param>
        public async Task<User> RegisterUser(User user)
        {
            return await _userRepository.UserProfileCreateAsync(user);
        }

        /// <summary>
        /// Used to login an user by matching the entered email and password to the one provided in the db
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<User> LoginUser(string email, string password)
        {
            return await _userRepository.UserLoginAsync(email, password);

        }

        /// <summary>
        /// Retreives the entire list of the users appointments
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Appointment>> GetEntireUserAppointmentListAsync()
        {
            return await _userRepository.GetEntireUserAppointmentListAsync();
        }

        /// <summary>
        /// Retreives the list of the users (tutors or students) you have worked with.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetListOfUsersWorkedWithAsync()
        {
            return await _userRepository.GetListOfUsersWorkedWithAsync();
        }

        /// <summary>
        /// Used to send a message
        /// </summary>
        /// <param></param>
        public async Task<Message> SendMessageAsync(Message message)
        {
            return await _userRepository.SendMessageAsync(message);
        }

        public async Task<IEnumerable<Message>> GetListOfUsersReceivedMessagesAsync()
        {
            return await _userRepository.GetListOfUsersReceivedMessagesAsync();
        }

        public async Task<IEnumerable<Message>> GetListOfUsersSentMessagesAsync()
        {
            return await _userRepository.GetListOfUsersSentMessagesAsync();
        }
    }
}