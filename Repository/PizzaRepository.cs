using la_mia_pizzeria_crud_mvc;
using la_mia_pizzeria_post.Models;
using la_mia_pizzeria_static.Data;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_post.Repository
{
    public class PizzaRepository
    {
        public PizzaContext _db;

        public PizzaRepository()
        {
            _db = new PizzaContext();
        }

        public List<Pizza> getPizza()
        {
            List<Pizza>? menu = _db.Pizzas.OrderBy(pizza => pizza.Name).Include("Category").Include("Ingredients").ToList<Pizza>();

            return menu;
        }

        public Pizza GetPizzaFromId(int id, bool ingredientsList)
        {
            Pizza? pizza = null;

            if (ingredientsList)
            {

                try
                {
                    pizza = _db.Pizzas.Where(dbPizza => dbPizza.PizzaId == id).Include(dbPizza => dbPizza.Category).Include("Ingredients").First();
                    return pizza;


                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);

                }

            }
            else
            {
                pizza = _db.Pizzas.Where(dbPizza => dbPizza.PizzaId == id).Include(dbPizza => dbPizza.Category).First();
            }

           
            return pizza;

        }


    }
}
