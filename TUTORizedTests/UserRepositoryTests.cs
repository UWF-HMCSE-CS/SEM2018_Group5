
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
using TUTORized.Services.Abstract;

namespace TUTORizedTests
{
    [TestClass]
    public class UserRepositoryTests : BaseTest
    {

        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserRepositoryTests()
        {
            _userRepository = new UserRepository(_connection);
        }

        [TestMethod]
        public async Task UserProfileCreateAsync_ShouldPopulateDatabaseWithUserAndReturnThatUser()
        {
            //ARRANGE
            var user = new User()
            {
                Email = "test@test.com",
                Password = "TestPassword",
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Role = "Tester"
            };


            //ACT
            User retrievedUser = await _userRepository.UserProfileCreateAsync(user);

            //ASSERT
            Assert.AreEqual(user.Email, retrievedUser.Email);
            await _userRepository.UserProfileDeleteByEmailAsync(user.Email);
        }

        [TestMethod]
        public async Task GetUserByEmailAsync_ShouldReturnUser()
        {
            //ARRANGE
            string email = "wesTest@test.com";
            string userId = "2";//"A12E8839-FB3B-4C14-AC64-D71657490985";

            //ACT
            User user = await _userRepository.GetUserByEmailAsync(email);

            //ASSERT
            Assert.AreEqual(userId, user.Id);
        }

        [TestMethod]
        public async Task GetUserByIdAsync_ShouldReturnUser()
        {
            //ARRANGE
            string email = "wesTest@test.com";
            string userId = "A12E8839-FB3B-4C14-AC64-D71657490985";

            //ACT
            var user = await _userRepository.GetUserByIdAsync(userId);

            //ASSERT
            Assert.AreEqual(email, user.Email);

        }

        [TestMethod]
        public async Task UserProfileUpdateAsync_ShouldUpdateDatabaseWithNewUserInfoAndReturnThatUser()
        {
            //ARRANGE
            var user = new User()
            {
                Email = "test@test.com",
                Password = "TestPassword",
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Role = "Tester"
            };
            user = await _userRepository.UserProfileCreateAsync(user);
            var changedEmail = "ChangedEmail@test.com";
            user.Email = changedEmail;

            //ACT
            User retrievedUser = await _userRepository.UserProfileUpdateAsync(user);

            //ASSERT
            Assert.AreEqual(retrievedUser.Email, changedEmail);
            await _userRepository.UserProfileDeleteByEmailAsync(user.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task UserProfileDeleteAsync_ShouldDeleteUserFromDatabase()
        {
            //ARRANGE
            var user = new User()
            {
                Email = "test@test.com",
                Password = "TestPassword",
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Role = "Tester"
            };
            user = await _userRepository.UserProfileCreateAsync(user);

            //ACT
            await _userRepository.UserProfileDeleteByEmailAsync(user.Email);
            user = await _userRepository.GetUserByEmailAsync(user.Email);

            //ASSERT
            Assert.AreEqual("test@test.com", user.Email);
        }

        [TestMethod]
        public async Task UserLoginByEmailAndPassword_ShouldLetTheUserLogin()
        {
            var user = new User()
            {
                Email = "test@test.com",
                Password = "TestPassword",
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Role = "Tester"
            };
            user = await _userRepository.UserProfileCreateAsync(user);

            //ACT
            User x = await _userRepository.UserLoginAsync(user.Email, user.Password);

            //ASSERT
            Assert.AreEqual("TestPassword", x.Password);

            await _userRepository.UserProfileDeleteByEmailAsync(user.Email);

        }

    }
}

