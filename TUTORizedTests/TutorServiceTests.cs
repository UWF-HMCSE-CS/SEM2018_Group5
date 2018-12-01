using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TUTORized.Models;
using TUTORized.Repository.Abstract;
using TUTORized.Services;

namespace TUTORizedTests
{
    [TestClass]
    public class TutorServiceTests : BaseTest
    {
        private readonly TutorService _sut;
        private readonly Mock<ITutorRepository> _tutorRepositoryMock;
        private Appointment appointment;
        private User user;
        List<User> mockList;

        public TutorServiceTests()
        {
            //Mock dependancies
            _tutorRepositoryMock = new Mock<ITutorRepository>();

            //Construct system under test (sut)
            _sut = new TutorService(_tutorRepositoryMock.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            DateTime dateTime = new DateTime(2018, 03, 20, 00, 00, 00, 000);
            appointment = new Appointment();
            appointment.StudentId = "22222";
            appointment.TutorId = "33333";
            appointment.Date = dateTime;
            appointment.Duration = "60";
            appointment.Subject = "Science";
            appointment.StudentFirstName = "studentfirst";
            appointment.StudentLastName = "studentlast";
            appointment.TutorFirstName = "tutorfirst";
            appointment.TutorLastName = "tutorlast";

            user = new User();
            user.Email = "TutorServiceTest@email.com";
            user.FirstName = "FirstName";
            user.LastName = "LastName";
            user.Password = "password";
            user.Role = "Student";

            mockList = new List<User>();
            mockList.Add(user);
        }

        [TestMethod]
        public async Task CreateAppointment_ShouldPopulateDatabaseWithApptAndReturnThatAppt()
        {
            //ARRANGE
            _tutorRepositoryMock.Setup(_tutorRepositoryMock => _tutorRepositoryMock.CreateAppointment(appointment)).Returns(Task.FromResult(appointment));

            //ACT
            _sut.CreateAppointment(appointment);


            //ASSERT 
            _tutorRepositoryMock.Verify((_tutorRepositoryMock => _tutorRepositoryMock.CreateAppointment(appointment)), Times.Once);
        }

        [TestMethod]
        public async Task GetEntireStudentListAsync_ShouldReturnListOfStudents()
        {
            //ARRANGE
            _tutorRepositoryMock.Setup(_tutorRepositoryMock => _tutorRepositoryMock.GetEntireStudentListAsync()).Returns(Task.FromResult((IEnumerable<User>)mockList));
            int students = 0;

            //ACT
            var studentList = await _sut.GetEntireStudentListAsync();
            foreach (User student in studentList)
            {
                students++;
            }

            //ASSERT
            Assert.IsTrue(students > 0, "The students were not greater than 0");
        }

        [TestMethod]
        public async Task UpgradeStudentToTutorAsync_ShouldUpdateUserRoleToTutorAndReturnUpdatedUser()
        {
            //ARRANGE
            _tutorRepositoryMock.Setup(_tutorRepositoryMock => _tutorRepositoryMock.UserProfileUpdateAsync(user)).Returns(Task.FromResult(user));

            //ACT
            await _sut.UpgradeStudentToTutorAsync(user);


            //ASSERT
            Assert.AreEqual("Tutor", user.Role);
        }
    }
}
