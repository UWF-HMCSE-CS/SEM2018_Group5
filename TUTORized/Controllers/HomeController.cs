using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TUTORized.Repository;

namespace TUTORized.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index() 
        {
            BaseRepository br = new BaseRepository();
            await br.TestConnection();
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
