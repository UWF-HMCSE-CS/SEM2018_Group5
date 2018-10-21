using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        private readonly UserService _sut;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private User user;
        List<User> mockList;

        public UserServiceTests()
        {
            //Mock dependancies
            _userRepositoryMock = new Mock<IUserRepository>();

            //Construct system under test (sut)
            _sut = new UserService(_userRepositoryMock.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            user = new User();
            user.Email = "UserServiceTest@email.com";
            user.FirstName = "FirstName";
            user.LastName = "LastName";
            user.Password = "password";
            user.Role = "tutor";
        }

        [TestMethod]
        public async Task RegisterUser_ShouldPopulateDatabaseWithUserAndReturnThatUser()
        {
            //ARRANGE
            _userRepositoryMock.Setup(_userRepositoryMock => _userRepositoryMock.UserProfileCreateAsync(user)).Returns(Task.FromResult(user));

            //ACT
            _sut.RegisterUser(user); 


            //ASSERT
            _userRepositoryMock.Verify((_userRepositoryMock => _userRepositoryMock.UserProfileCreateAsync(user)), Times.Once);
        }

        [TestMethod]
        public async Task UserLoginByEmailAndPassword_ShouldLetTheUserLogin()
        {
            //ARRANGE
            string email = user.Email;
            string password = user.Password;
            _userRepositoryMock.Setup(_userRepositoryMock => _userRepositoryMock.UserLoginAsync(user.Email, user.Password)).Returns(Task.FromResult(user));

            //ACT
            var retrievedUser = await _sut.LoginUser(email, password);

            //ASSERT
            Assert.AreEqual(user.Email, retrievedUser.Email);
        }
    }
}