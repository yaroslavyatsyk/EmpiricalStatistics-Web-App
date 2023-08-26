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
                ViewBag.Mode = model.Mode();
                ViewBag.Median = model.Median();
                ViewBag.Swing = model.DataSwing();
                ViewBag.Dispersion = model.Dispercion();
                ViewBag.AverageEmpirical = model.AverageEmpirical();

                ViewBag.Fluctuation = model.Fluctuation();
                ViewBag.Asymmetry = model.Asymmetry();
                ViewBag.Excess = model.Excess();
                ViewBag.Variation = model.Variation();

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
    }
}
