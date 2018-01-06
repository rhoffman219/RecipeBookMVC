using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBookMVC.Models
{
    public class RecipeCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<Recipe> Recipes { get; set; }
        public object RecipeID { get; internal set; }
        public object CategoryID { get; internal set; }
    }
}
