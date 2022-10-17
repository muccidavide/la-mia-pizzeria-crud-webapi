using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace la_mia_pizzeria_crud_mvc.Controllers
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

        //[HttpGet("{id:int}")]
        public IActionResult Details(int id)
        {
           /* Pizza pizza;

            pizza = _db.Pizzas.Where(dbPizza => dbPizza.PizzaId == id).Include(dbPizza => dbPizza.Category).First();*/

            return View("Details", id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}