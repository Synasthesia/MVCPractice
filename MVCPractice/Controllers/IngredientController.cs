using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCPractice.Data;
using MVCPractice.Models;

namespace MVCPractice.Controllers
{
    public class IngredientController : Controller
    {
        public readonly RecipeManagementContext _context;
        public IngredientController(RecipeManagementContext context)
        {
            _context = context;
        }
        //index = list of ingredients in recipe
        public IActionResult Index()
        {
            List<IngredientModel> ingredients = _context.Ingredients.Include(r => r.Recipe).ToList();
            return View(ingredients);
        }
        //view for when user clicks on "details" of a specific ingredient
        public IActionResult Details(int id)
        {
            var ingredient = _context.Ingredients.Include(i => i.Recipe).FirstOrDefault(m => m.Id == id);
            if (ingredient == null) { return NotFound(); }
            return View(ingredient);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IngredientModel ingredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredient);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }

        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Edit(int id, IngredientModel ingredient)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(ingredient).State = EntityState.Modified;
            }
            return View();
        }
    }
}
