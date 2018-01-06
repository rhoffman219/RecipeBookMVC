using RecipeBookMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBookMVC.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public IEnumerable<RecipeCategory> categories;

        public AddCategoryViewModel() { }
    }
}
