using la_mia_pizzeria_crud_mvc;
using la_mia_pizzeria_post.Models;
using la_mia_pizzeria_post.Repository;
using la_mia_pizzeria_static.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_crud_mvc.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        

        PizzaContext _db;
        PizzaRepository _rep;
        public PizzaController()
        {
            _db = new PizzaContext();
            _rep = new PizzaRepository();
        }

        public IActionResult Get(string? title)
        {
           if(title == null)
            {
                List<Pizza> pizzas = _rep.getPizza();
                return Ok(pizzas);
            }
            else
            {

                List<Pizza>? pizzas = _db.Pizzas.Where(p => p.Name != null && p.Name.ToLower().Contains(title)).ToList();
                return Ok(pizzas);
            }
            
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id)
        {
            Pizza? pizza = _rep.GetPizzaFromId(id, true);

            return Ok(pizza);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] PizzasCategories formPizza)
        {
            Pizza? pizzaToUpdate = _rep.GetPizzaFromId(id, true);
            if (pizzaToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                pizzaToUpdate.Name = formPizza.Pizza.Name;
                pizzaToUpdate.Description = formPizza.Pizza.Description;
                pizzaToUpdate.Image = formPizza.Pizza.Image;
                pizzaToUpdate.Price = formPizza.Pizza.Price;
                pizzaToUpdate.CategoryId = formPizza.Pizza.CategoryId;
                pizzaToUpdate.Ingredients = _rep.GetSelectedIngredients(formPizza);
                
                try
                {
                    _db.SaveChanges();
                    return Ok(pizzaToUpdate);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return NotFound();
                }

               
            }
        }

        
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Pizza? pizzaToRemove = _rep.GetPizzaFromId(id,false);

            if(pizzaToRemove == null)
            {
                return NotFound();
            }

            _db.Pizzas.Remove(pizzaToRemove);
            _db.SaveChanges();
            return Ok();

        }
    }
}
