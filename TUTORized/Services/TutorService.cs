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
File Name: TutorService.cs 
    This class provides the logic for all Tutor actions.
*/

namespace TUTORized.Services
{
    public class TutorService : ITutorService
    {
        private readonly ITutorRepository _tutorRepository;

        public TutorService(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }

        /// <summary>
        /// Used to Register a new User by creating a new user object and saving the 
        /// information to the Database
        /// </summary>
        /// <param name="user"></param>
        public async Task<Models.Message> CreateAppointment(Models.Message appointment)
        {
            return await _tutorRepository.CreateAppointment(appointment);
        }
    }
}