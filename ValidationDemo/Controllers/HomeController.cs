using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ValidationDemo.Models;

namespace ValidationDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // 1. Форманы ашу үшін (GET)
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // 2. Форманы қабылдап, валидация жасау үшін (POST)
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            // Міне, тапсырмадағы ModelState тексеруі!
            if (ModelState.IsValid)
            {
                // Егер барлық ереже дұрыс болса, осында кіреді
                ViewBag.Message = "Сәтті тіркелдіңіз, брат!";
                return View("Success");
            }

            // Егер қате болса, форманы қайтадан көрсетеді
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}