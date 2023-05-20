using CodingTest_Application.Models;
using CodingTest_Application.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;

namespace CodingTest_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Calc( int[] result)
        {
            if (result.Length == 0)
            {
                return View();
            }
            else
            {
                ViewBag.Result = result[0];
                ViewBag.X = result[1];
                ViewBag.Y = result[2];
                return View();
            }
        }

        public IActionResult Submit(string param, int x, int y)
        {
            commonClass commonClass = new commonClass();     
            int res = commonClass.callFunction(param, x, y);
            int []elements = new int[] {res, x, y};
            return RedirectToAction("Calc", "Home", new { result = elements});
        }

        public IActionResult Reset()
        {           
            var elements = Enumerable.Range(0,0).ToArray();
            return RedirectToAction("Calc", "Home", new { result = elements });
        }

    }
}