﻿using la_mia_pizzeria_crud_mvc.Validations;
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

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il nome non può avere più di 100 caratteri")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio"),]
        [MoreThanFiveWordsValidation]

        public string? Description { get; set; } = null;
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string? Image { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(1, 1000, ErrorMessage = "Il campo deve essere compreso tra 1 e 1000")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<Ingredient>? Ingredients { get; set; }




    }
}
