
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
    public class StudentServiceTests : BaseTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentService _studentService;
        User user;

        public StudentServiceTests()
        {
            _userRepository = new UserRepository(_connection);
            _studentRepository = new StudentRepository(_connection);
            //_studentService = new StudentService();

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

            _userRepository.UserProfileCreateAsync(user);
        }

        [TestMethod]
        public async Task ListOfTutorsGetAsync_ShouldReturnListOfTutors()
        {
            //ARRANGE
            int tutors = 0;
            var tutorList = await _studentService.ListOfTutorsGetAsync();

            //ACT
            foreach (User tutor in tutorList)
            {
                tutors++;
            }

            //ASSERT
            Assert.IsTrue(tutors > 0, "The tutors were not greater than 0");
        }

        public void CleanUpAfterTests()
        {
            _userRepository.UserProfileDeleteByEmailAsync(user.Email);
        }
    }
}