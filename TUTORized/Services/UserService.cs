using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Models;
using TUTORized.Repository.Abstract;

namespace TUTORized.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUserObject()
        {
            var newUserObject = new User();
            return newUserObject;
        }

        public User CreateUserObject(string email, string password, string firstName, string lastName, string role)
        {
            var newUserObject = new User(email, password, firstName, lastName, role);
            return newUserObject;
        }

        public User CreateUserObject(string id, string email, string password, string firstName, string lastName, string role)
        {
            var newUserObject = new User(id, email, password, firstName, lastName, role);
            return newUserObject;
        }

        public async Task RegisterUser(string email, string password, string firstName, string lastName, string role)
        {
            var user = CreateUserObject(email, password, firstName, lastName, role);
            await _userRepository.UserProfileCreateAsync(user);
        }
    }
}
