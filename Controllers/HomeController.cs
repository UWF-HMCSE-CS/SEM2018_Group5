using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TUTORized.Repository;

namespace TUTORized.Controllers
{
    public class HomeController : Controller
    {
        //Testing a push to multiple repos.
        public async Task<IActionResult> Index() 
        {
            BaseRepository br = new BaseRepository();
            await br.testConnection();
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
