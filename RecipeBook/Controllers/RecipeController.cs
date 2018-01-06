using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Data;
using RecipeBookMVC.Models;
using RecipeBookMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace RecipeBookMVC.Controllers
{
    public class RecipeController : Controller
    {
        private RecipeDbContext context;

        public RecipeController(RecipeDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            IList<Recipe> recipes = context.Recipes.Include(c => c.Category).ToList();

            return View(recipes);
        }

        public IActionResult Add()
        {
            AddRecipeViewModel addRecipeViewModel = new AddRecipeViewModel(context.Categories.ToList());

            return View(addRecipeViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddRecipeViewModel addRecipeViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new recipe to my existing recipes

                RecipeCategory newRecipeCategory = context.Categories.Single(c => c.ID == addRecipeViewModel.CategoryID);

                Recipe newRecipe = new Recipe
                {
                    Name = addRecipeViewModel.Name,
                    Description = addRecipeViewModel.Description,
                    Category = newRecipeCategory
                };

                context.Recipes.Add(newRecipe);
                context.SaveChanges();
                
                return Redirect("/Recipe");
            }

            return View(addRecipeViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Recipes";

            ViewBag.recipes = context.Recipes.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] recipeIds)
        {
            foreach (int recipeId in recipeIds)
            {
                Recipe theRecipe = context.Recipes.Single(c => c.ID == recipeId);
                context.Recipes.Remove(theRecipe);
            }

            context.SaveChanges();

            return Redirect("/");
        }

    }

}
