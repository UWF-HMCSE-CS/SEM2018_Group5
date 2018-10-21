using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TUTORized.Controllers;
using TUTORized.Models;
using TUTORized.Repository;
using TUTORized.Repository.Abstract;
using TUTORized.Services;
using TUTORized.Services.Abstract;

namespace TUTORizedTests
{
    [TestClass]
    public class UserServiceTests : BaseTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        User user;

        public UserServiceTests()
        {
            _userRepository = new UserRepository(_connection);
            //_userService = new UserService();

        }

        [TestInitialize]
        public void Initialize()
        {
            user = new User();
            user.Email = "StudServiceTest@email.com";
            user.FirstName = "FirstName";
            user.LastName = "LastName";
            user.Password = "password";
            user.Role = "tutor";
        }

        [TestMethod]
        public async Task RegisterUser_ShouldPopulateDatabaseWithUserAndReturnThatUser()
        {
            //ARRANGE
            var email = "StudServiceTest@email.com";

            //ACT
            _userService.RegisterUser(user);
            var retrievedUser = await _userRepository.GetUserByEmailAsync(email);

            //ASSERT
            Assert.AreEqual(user.Email, retrievedUser.Email);
        }

        [TestMethod]
        public async Task UserLoginByEmailAndPassword_ShouldLetTheUserLogin()
        {

            //ACT
            var retrievedUser = await _userRepository.UserLoginAsync(user.Email, user.Password);

            //ASSERT
            Assert.AreEqual(user.Email, retrievedUser.Email);
        }

        public void CleanUpAfterTests()
        {
            _userRepository.UserProfileDeleteByEmailAsync(user.Email);
        }
    }
}