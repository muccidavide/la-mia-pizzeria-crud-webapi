using la_mia_pizzeria_crud_mvc;
using la_mia_pizzeria_static.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace la_mia_pizzeria_crud_mvc.Controllers.Api
{
    [Route("api/pizza/")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        

        PizzaContext _db;
        public PizzaController()
        {
            _db = new PizzaContext();
        }

        public IActionResult Get(string? title)
        {
           if(title == null)
            {
                List<Pizza> pizzas = _db.Pizzas.ToList();
                return Ok(pizzas);
            }
            else
            {
                List<Pizza> pizzas = _db.Pizzas.Where(p => p.Name.ToLower().Contains(title)).ToList();
                return Ok(pizzas);
            }
            
            
            
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id)
        {
            Pizza pizza = _db.Pizzas.Include("Ingredients").SingleOrDefault(pizza => pizza.PizzaId == id);

            return Ok(pizza);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Pizza pizzaToRemove = _db.Pizzas.SingleOrDefault(pizza => pizza.PizzaId == id);

            if(pizzaToRemove == null)
            {
                return NotFound();
            }

            _db.Pizzas.Remove(pizzaToRemove);
           // _db.SaveChanges();
            return Ok();

        }
    }
}
