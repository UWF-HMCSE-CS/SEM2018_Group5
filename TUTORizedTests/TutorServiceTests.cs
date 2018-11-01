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
    }
}
