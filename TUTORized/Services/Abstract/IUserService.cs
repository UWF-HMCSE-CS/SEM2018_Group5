using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
File Name: IUserService.cs 
    This class is the interface for the UserService class.
*/

namespace TUTORized.Services.Abstract
{
    public interface IUserService
    {
        User CreateUserObject();


        User CreateUserObject(string email, string password, string firstName, string lastName, string role);


        User CreateUserObject(string id, string email, string password, string firstName, string lastName, string role);


        void RegisterUser(string email, string password, string firstName, string lastName, string role);

    }
}
