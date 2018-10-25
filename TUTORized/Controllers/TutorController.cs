using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Models;
using TUTORized.Services.Abstract;

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

        [HttpPost("createAppointment")]
        public async Task<IActionResult> CreateTutorAppointment([FromBody] Appointment appointment)
        {
            return Ok(await _tutorService.CreateAppointment(appointment));
        }
    }

}
