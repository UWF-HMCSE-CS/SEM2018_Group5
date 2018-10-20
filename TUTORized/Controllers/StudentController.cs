using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TUTORized.Models;
using TUTORized.Services.Abstract;

namespace TUTORized.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/Student/GetListOfAllTutors
        [HttpGet]
        public IEnumerable<User> GetListOfAllTutors()
        {
            var listOfTutors =  _studentService.ListOfTutorsGetAsync();
            return (IEnumerable<User>) listOfTutors;
            //I feel like you want a list of Users meeting the "tutor" criteria then you will match it with
            //the front end User Objects and display their first and last name.... If you would rather me 
            //extract their first and last names in StudentServices and pass just a string up I can, 
            //but I figured if we did that then we would have to pass the name back down (then retreive the User) 
            //when we later select one of the Tutors....... not sure if you understand what i mean though?
            //return new string[] { "value1", "value2" };
        }

    }
}
