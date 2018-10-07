using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TUTORized.Repository;
using TUTORized.Repository.Abstract;

namespace TUTORized.Controllers
{
    public class HomeController : Controller
    {
        //FOR TESTING PURPOSES ONLY
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            //FOR TESTING PURPOSES ONLY-------------
            var email = "test@test.com";
            var test = await _userRepository.GetUserByEmailAsync(email);
            //---------------------------------------


            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
