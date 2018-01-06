using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBookMVC.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Ingredient { get; set; }
        public string Instructions { get; set; }
        
        public RecipeCategory Category { get; set; }

    }
}
