using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Models;
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
        public Task<List<User>> ListOfTutorsGet()
        {
            return null;
        }
    }
}
