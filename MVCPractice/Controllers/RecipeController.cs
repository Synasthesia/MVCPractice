using Microsoft.AspNetCore.Mvc;
using MVCPractice.Data;
using MVCPractice.Models;

namespace MVCPractice.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RecipeManagementContext _context;

        public RecipeController(RecipeManagementContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<RecipeModel> recipes = _context.Recipes.ToList();
            return View(recipes);
        }
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            } else
            {
                RecipeModel recipe = _context.Recipes.Find(id);
                return View(recipe);
            }
        }
    }
}
