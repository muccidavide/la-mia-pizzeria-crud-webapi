using la_mia_pizzeria_post.Models;
using la_mia_pizzeria_static.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_post.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        PizzaContext _db;
        public CategoryController()
        {
            _db = new PizzaContext();
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<Category> categories = _db.Categories.ToList();
            return Ok(categories);
        }
    }
}
