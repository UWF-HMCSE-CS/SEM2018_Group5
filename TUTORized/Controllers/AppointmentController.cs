using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Services.Abstract;

namespace TUTORized.Controllers
{
    [Produces("application/json")]
    [Route("api/Appointment")]
    public class AppointmentController : Controller 
    {

        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET : api/Appointment/GetListOfAllAppointments

        [HttpGet]
        public async Task<IActionResult> GetListOfAllAppointment()
        {

        }
    }
}
