using la_mia_pizzeria_post.Models;
using la_mia_pizzeria_static.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_post.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        PizzaContext _db;
        public IngredientController()
        {
            _db = new PizzaContext();
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<Ingredient> ingredients = _db.Ingredients.ToList();
            return Ok(ingredients);
        }
    }
}
