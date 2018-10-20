using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Models;
using TUTORized.Repository.Abstract;

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
File Name: StudentRepository.cs 
    This class acts acts as an intermediary between the 
    BaseRepository and the logic related to the Student in 
    order to relay CRUD operations with the DataBase.
*/

namespace TUTORized.Repository
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public StudentRepository(string connection) : base(connection)
        {

        }

        /// <summary>
        /// Retrieves a Tutor from the database by their email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User> GetTutorByEmailAsync(string email)
        {
            //Initializes Parameters for Stored Procedure
            var parameters = new DynamicParameters();

            //Adds to Parameters
            parameters.Add("Email", email);

            return await FirstJsonResultAsync<User>("readUserByEmail", parameters);
        }

        /// <summary>
        /// Retrieves all Tutors from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetEntireTutorListAsync()
        {
            //Initializes Parameters for Stored Procedure
            var parameters = new DynamicParameters();

            return await JsonResultAsync<User>("readTutorsAll", parameters);
        }

        /// <summary>
        /// Retrieves a Tutor from the database by their subject of expertise
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetTutorListBySubjectAsync(string subject)
        {
            //Initializes Parameters for Stored Procedure
            var parameters = new DynamicParameters();

            //Adds to Parameters
            parameters.Add("Subject", subject);

            return await JsonResultAsync<User>("readTutorBySubject", parameters);
        }
    }
}
