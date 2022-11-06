using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;
using la_mia_pizzeria_static.Data;
using Microsoft.IdentityModel.Tokens;
using la_mia_pizzeria_post.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using la_mia_pizzeria_post.Repository;

namespace la_mia_pizzeria_crud_mvc.Controllers
{
    [Authorize]
    public class PizzaController : Controller
    {
        PizzaRepository _rep;
        PizzaContext _db;
        List<Category> _categories;
        List<Ingredient> _ingredients;
        PizzasCategories pizzasCategories;


        public PizzaController()
        {
            _rep = new PizzaRepository();
            this._db = _rep._db;
            this._categories = _db.Categories.ToList();
            this._ingredients = _db.Ingredients.ToList();
            this.pizzasCategories = new PizzasCategories();
            pizzasCategories.Categories = _categories;
            pizzasCategories.Ingredients = _ingredients;

        }
        /*
         CREATE
         */
        public IActionResult Create()
        {
            pizzasCategories.Categories = _categories;
            pizzasCategories.Ingredients = _ingredients;
            return View("Create", pizzasCategories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzasCategories formPizza)
        {

            if (!ModelState.IsValid)
            {
                formPizza.Categories = _categories;
                formPizza.Ingredients = _ingredients;
                if(formPizza.SelectedIngredients != null)
                {
                    formPizza.Pizza.Ingredients = _db.Ingredients.Where(ingredient => formPizza.SelectedIngredients.Contains(ingredient.IngredientId)).ToList<Ingredient>();
                }
                
                return View("Create", formPizza);
            }

            if (formPizza.SelectedIngredients != null)
            {
                formPizza.Pizza.Ingredients = _db.Ingredients.Where(ingredient => formPizza.SelectedIngredients.Contains(ingredient.IngredientId)).ToList<Ingredient>();
            }

            try
            {
                _db.Pizzas.Add(formPizza.Pizza);
                _db.SaveChanges();
            }
            catch (SqlException ex)
            {
                ModelState.AddModelError("StoreDataExcetipn", ex.Message);
                formPizza.Categories = _categories;
                return View("Create", formPizza);

            }
            return RedirectToAction("Index");
        }

        /*
         INDEX & DETAILS
         */
        [HttpGet]
        public IActionResult Index()
        {

            List<Pizza> myMenu = _rep.getPizza();

            return View("Index", myMenu);
        }

        public IActionResult Details(int id)
        {

            Pizza pizza = _rep.GetPizzaFromId(id, true);
            if (pizza == null)
            {
                return NotFound();
            }
            return View("Show", pizza);
        }

        /*
         UPDATE
         */
        [HttpGet]
        public IActionResult Update(int id)
        {
            Pizza pizzaToUpdate = _rep.GetPizzaFromId(id,true);


            if (pizzaToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                pizzasCategories.Pizza = pizzaToUpdate;
                //

                return View("Update", pizzasCategories);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzasCategories formPizza)
        {
            Pizza pizzaToUpdate = _rep.GetPizzaFromId(id, true);

            if (!ModelState.IsValid)
            {
                formPizza.Categories = _categories;
                formPizza.Ingredients = _ingredients;
                formPizza.Pizza.Ingredients = _db.Ingredients.Where(ingredient => formPizza.SelectedIngredients.Contains(ingredient.IngredientId))?.ToList<Ingredient>();

                return View("Update", formPizza);
            }

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
                pizzaToUpdate.Ingredients = _db.Ingredients.Where(ingredient => formPizza.SelectedIngredients.Contains(ingredient.IngredientId)).ToList<Ingredient>();

                try
                {
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("StoreDataExcetipn", ex.Message);
                    formPizza.Categories = _categories;
                    formPizza.Ingredients = _ingredients;
                    return View("Update", formPizza);

                }

                return RedirectToAction("Index");
            }

        }

        /*
         DELETE
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
             Pizza pizzaToRemove = _db.Pizzas.Where(dbPizza => dbPizza.PizzaId == id).First();

            if (pizzaToRemove == null)
            {
                return NotFound();
            }
            _db.Pizzas.Remove(pizzaToRemove);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}