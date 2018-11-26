using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Models;
using TUTORized.Repository.Abstract;
using TUTORized.Services.Abstract;

/**
TUTORized is a web application designed for use in 
schools. Students can coordinate with Tutors to set 
up tutoring sessions. Students and Tutors are also 
able to message each other, as well as share resources
with each other.
@author Timothy McWatters
@author Keenal Shah
@author Wesley Easton
@author Wenwen Xu
@version 1.0
CEN4053    "TUTORized" SEM- Group 5's class project
File Name: ServiceService.cs 
    This class provides the logic for all Student actions.
*/

namespace TUTORized.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        private readonly IMessageService _messageService;

        private readonly ITutorRepository _tutorRepository;

        public StudentService(IStudentRepository studentRepository, IMessageService messageService, 
            ITutorRepository tutorRepository)
        {
            _studentRepository = studentRepository;
            _messageService = messageService;
            _tutorRepository = tutorRepository;
        }

        /// <summary>
        /// Retreives the entire list of tutors
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> ListOfTutorsGetAsync()
        {
            return await _studentRepository.GetEntireTutorListAsync();
        }

        /// <summary>
        /// Retreives the entire list of available appointments
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Appointment>> GetListOfAllAvailableAppointmentsAsync()
        {
            return await _studentRepository.GetListOfAllAvailableAppointmentsAsync();
        }

        /// <summary>
        /// Allows a student to make an appointment
        /// </summary>
        /// <param></param>
        public async Task<Appointment> MakeStudentAppointment(Appointment appointment, string email)
        {
            var toEmail = await _tutorRepository.GetTutorEmailById(appointment.TutorId);
            var subject = "An appointment has been booked";
            var message = appointment.StudentFirstName + " " + appointment.StudentLastName + " has booked an " +
                          "appointment on " + appointment.Date + " for help in " + appointment.Subject;

            await _messageService.SendAppointmentMadeEmailAsync(toEmail, subject, message);

            message = "You have booked an appointment on " + appointment.Date + " for help in " + appointment.Subject;
            await _messageService.SendConfirmEmailAsync(email, subject, message);
            return await _studentRepository.MakeStudentAppointment(appointment);
        }
    }
}
