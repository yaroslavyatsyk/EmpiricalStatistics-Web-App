using EmpiricalStatistics_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmpiricalStatistics_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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


        [HttpGet]

        public IActionResult Index()
        {
            ViewBag.Mode = 0;
            ViewBag.Median = 0;
            ViewBag.Swing = 0;
            ViewBag.Dispersion = 0;
            ViewBag.AverageEmpirical = 0;

            ViewBag.Fluctuation = 0;
            ViewBag.Asymmetry = 0;
            ViewBag.Excess = 0;
            ViewBag.Variation = 0;


            return View();
        }

        [HttpPost]

        public IActionResult Index(Empirical model)
        {

            if (ModelState.IsValid)
            {

                model.SetValue();
                ViewBag.Mode = Math.Round(model.Mode(),3);
                ViewBag.Median = Math.Round(model.Median(),3);

                ViewBag.Swing = Math.Round(model.DataSwing(),3);
          
                ViewBag.Dispersion = Math.Round(model.Dispercion(), 3);
                ViewBag.AverageEmpirical = Math.Round(model.AverageEmpirical(), 3);

                ViewBag.Fluctuation = Math.Round(model.Fluctuation(), 3);
                ViewBag.Asymmetry = Math.Round(model.Asymmetry(), 3);
                ViewBag.Excess = Math.Round(model.Excess(), 3);
                ViewBag.Variation = Math.Round(model.Variation(), 3);

                ViewBag.list = model.GetArray();

                ViewBag.Max = model.GetArray().Max();
                ViewBag.Min = model.GetArray().Min();

                ViewBag.Freq = model.GetFrequencies();

                return View(model);


            }
            else
            {

                ViewBag.Mode = 0;
                ViewBag.Median = 0;
                ViewBag.Swing = 0;
                ViewBag.Dispersion = 0;
                ViewBag.AverageEmpirical = 0;
                ViewBag.Fluctuation = 0;
                ViewBag.Asymmetry = 0;
                ViewBag.Excess = 0;
                ViewBag.Variation = 0;
                ViewBag.Max = 0;
                ViewBag.Min = 0;
                return View();
            }


            
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
