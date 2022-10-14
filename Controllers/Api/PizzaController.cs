using la_mia_pizzeria_crud_mvc;
using la_mia_pizzeria_static.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace la_mia_pizzeria_crud_mvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        PizzaContext _db;
        public PizzaController()
        {
            _db = new PizzaContext();
        }

        public IActionResult GetPizzas()
        {
           
            List<Pizza> pizzas = _db.Pizzas.ToList();
            
            return Ok(pizzas);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id)
        {
            Pizza pizza = _db.Pizzas.SingleOrDefault(pizza => pizza.PizzaId == id);

            return Ok(pizza);
        }
    }
}
