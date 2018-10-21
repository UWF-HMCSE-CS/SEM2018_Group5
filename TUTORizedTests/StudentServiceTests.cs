
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
    public class StudentServiceTests : BaseTest
    {
        private readonly StudentService _sut;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        private User user;
        List<User> mockList;

        public StudentServiceTests()
        {
            //Mock dependancies
            _userRepositoryMock = new Mock<IUserRepository>();
            _studentRepositoryMock = new Mock<IStudentRepository>();

            //Construct system under test (sut)
            _sut = new StudentService(_studentRepositoryMock.Object);
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

            mockList = new List<User>();
            mockList.Add(user);
            }

        [TestMethod]
        public async Task ListOfTutorsGetAsync_ShouldReturnListOfTutors()
        {
            //ARRANGE
            _studentRepositoryMock.Setup(_studentRepositoryMock => _studentRepositoryMock.GetEntireTutorListAsync()).Returns(Task.FromResult((IEnumerable<User>)mockList));
            int tutors = 0;

            //ACT
            var tutorList = await _sut.ListOfTutorsGetAsync();
            foreach (User tutor in tutorList)
            {
                tutors++;
            }

            //ASSERT
            Assert.IsTrue(tutors > 0, "The tutors were not greater than 0");
        }
    }
}