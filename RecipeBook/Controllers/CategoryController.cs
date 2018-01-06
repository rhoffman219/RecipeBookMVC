using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Data;
using RecipeBookMVC.ViewModels;
using RecipeBookMVC.Models;

namespace RecipeBookMVC.Controllers
{
    public class CategoryController : Controller
    {
        IActionResult Index()
        {
            var recipeCategory = context.Categories.ToList();

            return View(recipeCategory);
        }

        private readonly RecipeDbContext context;

        public CategoryController(RecipeDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();

            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                RecipeCategory newCategory = new RecipeCategory
                {
                    Name = addCategoryViewModel.Name
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
            }

            return View(addCategoryViewModel);
        }

    }

}