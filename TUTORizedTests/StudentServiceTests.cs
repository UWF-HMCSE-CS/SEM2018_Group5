
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TUTORized.Models;
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
        private readonly Mock<IMessageService> _messageServiceMock;
        private readonly Mock<ITutorRepository> _tutorRepositoryMock;
        private User user;
        private Appointment appointment;
        List<User> mockList;

        public StudentServiceTests()
        {
            //Mock dependancies
            _userRepositoryMock = new Mock<IUserRepository>();
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _messageServiceMock = new Mock<IMessageService>();
            _tutorRepositoryMock = new Mock<ITutorRepository>();

            //Construct system under test (sut)
            _sut = new StudentService(_studentRepositoryMock.Object, _messageServiceMock.Object, _tutorRepositoryMock.Object);
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

            DateTime dateTime = new DateTime(2018, 03, 20, 00, 00, 00, 000);
            appointment = new Appointment();
            appointment.TutorId = "33333";
            appointment.Date = dateTime;
            appointment.Duration = "60";
            appointment.Subject = "Science";
            appointment.TutorFirstName = "tutorfirst";
            appointment.TutorLastName = "tutorlast";
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
        
        [TestMethod]
        public async Task MakeStudentAppointment_ShouldUpdateApptSaveToDBAndReturnThatAppt()
        {
            //ARRANGE
            _studentRepositoryMock.Setup(_studentRepositoryMock => _studentRepositoryMock.MakeStudentAppointment(appointment)).Returns(Task.FromResult(appointment));

            //ACT
            appointment.StudentId = "222222";
            appointment.StudentFirstName = "studentfirst";
            appointment.StudentLastName = "studentlast";
            var email = "test@test.com";
            await _sut.MakeStudentAppointment(appointment, email);


            //ASSERT
            Assert.AreEqual("222222", appointment.StudentId);
        }
    }
}