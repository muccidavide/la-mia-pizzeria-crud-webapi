using la_mia_pizzeria_crud_mvc;
using la_mia_pizzeria_post.Models;
using la_mia_pizzeria_static.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_post.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        PizzaContext _db;
        public MessageController()
        {
            _db = new PizzaContext();
        }

        [HttpPost]
        public IActionResult Send([FromBody]Message messageData)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Contact", "Home", messageData);
            }
            Message newMessage = new Message();
            newMessage = messageData;
            _db.Messages.Add(newMessage);
            _db.SaveChanges();


            return RedirectToAction("Contact", "Home");

        }



        
    }
}
