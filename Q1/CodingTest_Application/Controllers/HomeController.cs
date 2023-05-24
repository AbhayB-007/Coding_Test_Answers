using CodingTest_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CodingTest_Application.IRepository;

namespace CodingTest_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IcommonClass Icommonclass;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IcommonClass Icommonclass)
        {
            _logger = logger;
            this.Icommonclass = Icommonclass;
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

        public IActionResult Calc(int[] result)
        {
            return View();            
        }

        public IActionResult Submit(string param, int x, int y)
        {
            int res = Icommonclass.callFunction(param, x, y);
            return Json(res);
        }

        public IActionResult Reset()
        {
            var elements = Enumerable.Range(0, 0).ToArray();
            return RedirectToAction("Calc", "Home", new { result = elements });
        }

    }
}