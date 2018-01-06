using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeBookMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBookMVC.ViewModels
{
    public class AddRecipeViewModel
    {
        [Required]
        [Display(Name = "Recipe Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your Recipe a description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }


        public List<SelectListItem> Categories { get; set; }

        public AddRecipeViewModel() { }


        public AddRecipeViewModel(IEnumerable<RecipeCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (RecipeCategory item in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Name
                });

            }

        }

    }
}
