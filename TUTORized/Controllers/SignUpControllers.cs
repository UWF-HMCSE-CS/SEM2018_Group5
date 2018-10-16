using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TUTORized.Repository;
using System.Collections.Generic;
using System.Linq;



namespace TUTORized.Controllers
{
    [Route("api/[controller]")]
    public class SignUpControllers : Controller
    {
       

        public void postUserDara(string firstName, string lastName, string userEmail, string userPassword)
        {
           


        }

        public class signUpScreen
        {
            public string userEmail { get; set; }
            public string userPassword { get; set; }
            public string conPassword { get; set; }
        }
    }
}
