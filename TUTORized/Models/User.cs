using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Repository;

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
File Name: User.cs 
    This class is the User Model. 
*/

namespace TUTORized.Models
{
    public class User
    {

        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

        ///// <summary>
        ///// Default Constructor
        ///// </summary>
        //public User()
        //{
        //    this.Id = "";
        //    this.Email = "";
        //    this.Password = "";
        //    this.FirstName = "";
        //    this.LastName = "";
        //    this.Role = "";
        //}


        ///// <summary>
        ///// Constructor with no ID; used for new User registration where an ID has not been assigned yet.
        ///// </summary>
        //public User(string email, string password, string firstName, string lastName, string role)
        //{
        //    this.Id = "";
        //    this.Email = email;
        //    this.Password = password;
        //    this.FirstName = firstName;
        //    this.LastName = lastName;
        //    this.Role = role;
        //}



        ///// <summary>
        ///// Constructor with ID; used to recreate an User object called from the database.
        ///// </summary>
        //public User(string id, string email, string password, string firstName, string lastName, string role)
        //{
        //    this.Id = id;
        //    this.Email = email;
        //    this.Password = password;
        //    this.FirstName = firstName;
        //    this.LastName = lastName;
        //    this.Role = role;
        //}





    }
}
