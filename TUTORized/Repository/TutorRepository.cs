using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Repository.Abstract;
using Dapper;
using TUTORized.Models;

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
File Name: TutorRepository.cs 
    This class acts acts as an intermediary between the 
    BaseRepository and the logic related to the User in 
    order to relay CRUD operations with the DataBase.
*/

namespace TUTORized.Repository
{
    public class TutorRepository : BaseRepository, ITutorRepository
    {
        public TutorRepository(string connection) : base(connection)
        {

        }

        /// <summary>
        /// Creates a database entry of a Appointment object
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            //Initializes Parameters for Stored Procedure
            var parameters = new DynamicParameters();

            //Adds to Parameters
            //parameters.Add("StudentId", appointment.StudentId);
            //parameters.Add("TutorId", appointment.TutorId);
            parameters.Add("UserId", loggedInUser.Id);
            parameters.Add("Date", appointment.Date);
            parameters.Add("Duration", "60");
            parameters.Add("Subject", appointment.Subject);
            parameters.Add("TutorFirstName", loggedInUser.FirstName);
            parameters.Add("TutorLastName", loggedInUser.LastName);

            var result = await FirstJsonResultAsync<Appointment>("createAppointment", parameters);
            return result;
        }
    }
}
