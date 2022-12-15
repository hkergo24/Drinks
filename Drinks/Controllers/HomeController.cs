using Drinks.DBContexts;
using Drinks.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Drinks.Controllers
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
            var drinks = new List<Drink>();
            using (var db = new DrinksContext())
            {
                ViewBag.Drinks = db.Drinks.Select(o => new { o.Id, o.Name, o.Price })
         .AsEnumerable()
         .ToDictionary(o => o.Id, o=> new { o.Name, o.Price });
            }

            return View();
        }

        [HttpGet("{id}")]
        public double GetDrinkPrice(int drinkId)
        {
            Drink drink;
            using (var db = new DrinksContext())
            {
                drink = db.Drinks.Find(drinkId);
            }
            if (drink != null)
                return drink.Price;
            return 0;
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
    }
}