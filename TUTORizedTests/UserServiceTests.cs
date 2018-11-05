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
    public class UserServiceTests : BaseTest
    {
        private readonly UserService _sut;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private User user;
        private Appointment appointment;
        List<Appointment> mockList;

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

            DateTime dateTime = new DateTime(2018, 03, 20, 00, 00, 00, 000);
            appointment = new Appointment();
            appointment.TutorId = "33333";
            appointment.Date = dateTime;
            appointment.Duration = "60";
            appointment.Subject = "Science";
            appointment.TutorFirstName = "tutorfirst";
            appointment.TutorLastName = "tutorlast";

            mockList = new List<Appointment>();
            mockList.Add(appointment);
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
        
        [TestMethod]
        public async Task GetEntireUserAppointmentListAsync_ShouldReturnListOfAppts()
        {
            //ARRANGE
            _userRepositoryMock.Setup(_userRepositoryMock => _userRepositoryMock.GetEntireUserAppointmentListAsync()).Returns(Task.FromResult((IEnumerable<Appointment>)mockList));
            int appts = 0;

            //ACT
            var apptList = await _sut.GetEntireUserAppointmentListAsync();
            foreach (Appointment appt in apptList)
            {
                appts++;
            }

            //ASSERT
            Assert.IsTrue(appts > 0, "The appointments were not greater than 0");
        }
    }
}