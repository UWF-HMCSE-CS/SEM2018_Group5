using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Models;

namespace TUTORized.Controllers
{
    [Route("api/tutor")]
    public class TutorController : Controller
    {
        private readonly ITutorService _tutorService;

        public TutorController(ITutorService tutorService)
        {
            _tutorService = tutorService;
        }

        [HttpGet("createAppointment")]
        public void CreateTutorAppointment([FromBody] User user)
        {
            _tutorService.CreateTutorAppoinment(user);
        }
    }

}
