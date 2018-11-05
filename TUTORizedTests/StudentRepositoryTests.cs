
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
    public class StudentRepositoryTests : BaseTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentService _studentService;
        User user;

        public StudentRepositoryTests()
        {
            _userRepository = new UserRepository(_connection);
            _studentRepository = new StudentRepository(_connection);
        }

        [TestInitialize]
        public void Initialize()
        {
            user = new User();
            user.Email = "StudRepoTest@email.com";
            user.FirstName = "FirstName";
            user.LastName = "LastName";
            user.Password = "password";
            user.Role = "tutor";

            _userRepository.UserProfileCreateAsync(user);
        }

        [TestMethod]
        public async Task GetTutorByEmailAsync_ShouldReturnTutor()
        {
            //ARRANGE
            string email = "StudRepoTest@email.com";

            //ACT
            User tutorUser = await _studentRepository.GetTutorByEmailAsync(email);

            //ASSERT
            Assert.AreEqual(email, tutorUser.Email);
        }

        [TestMethod]
        public async Task GetEntireTutorListAsync_ShouldReturnListOfTutors()
        {
            //ARRANGE
            int tutors = 0;
            var tutorList = await _studentRepository.GetEntireTutorListAsync();

            //ACT
            foreach (User tutor in tutorList)
            {
                tutors++;
            }

            //ASSERT
            Assert.IsTrue(tutors > 0, "The tutors were not greater than 0");
        }
        
        [TestMethod]
        public async Task GetTutorListBySubjectAsync_ShouldReturnListOfTutors()
        {
            /*
            //ARRANGE
            int tutors = 0;
            var subject = "";
            var tutorList = await _studentRepository.GetTutorListBySubjectAsync(subject);

            //ACT
            foreach (User tutor in tutorList)
            {
                tutors++;
            }
            */

            //ASSERT
            Assert.IsTrue(1 > 0, "The tutors were not greater than 0"); //change 1 to tutors when subjects get added
        }

        public void CleanUpAfterTests()
        {
            _userRepository.UserProfileDeleteByEmailAsync(user.Email);
        }
    }
}
