using la_mia_pizzeria_crud_mvc.Validations;
using la_mia_pizzeria_post.Models;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace la_mia_pizzeria_crud_mvc
{
    public class Pizza
    {
        public Pizza()
        {
            Ingredients = new List<Ingredient>();
        }
        public int PizzaId { get; private set; }

        [Required(ErrorMessage = "Il campo nome è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il nome non può avere più di 100 caratteri")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Il campo Descrizione è obbligatorio")]
        [MoreThanFiveWordsValidation(ErrorMessage = "Il campo Descrizione deve avere più di 5 parole")]

        public string? Description { get; set; } = null;
        [Required(ErrorMessage = "Il campo Image è obbligatorio")]
        public string? Image { get; set; }

     
        [Range(1, 1000, ErrorMessage = "Il campo Prezzo deve essere compreso tra 1 e 1000")]
        [Required(ErrorMessage = "Il campo Prezzo è obbligatorio")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Il campo Categoria è obbligatorio")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<Ingredient>? Ingredients { get; set; }




    }
}
