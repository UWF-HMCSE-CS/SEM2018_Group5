using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        [ProducesResponseType(typeof(IList<User>), 200)]
        public async Task<IActionResult> GetListOfAllTutors()
        {
            return Ok(await _studentService.ListOfTutorsGetAsync());
        }

        [HttpGet("getAppointments")]
        [ProducesResponseType(typeof(IList<Appointment>), 200)]
        public async Task<IActionResult> GetListOfAllAvailableAppointments()
        {
            return Ok(await _studentService.GetListOfAllAvailableAppointmentsAsync());
        }

        [HttpPost("makeStudentAppointment/{email}")]
        public async Task<IActionResult> MakeStudentAppointment([FromBody] Appointment appointment, string email)
        {
            return Ok(await _studentService.MakeStudentAppointment(appointment, email));
        }
    }
}
