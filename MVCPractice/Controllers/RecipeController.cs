using Microsoft.AspNetCore.Mvc;
using MVCPractice.Data;
using MVCPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCPractice.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RecipeManagementContext _context;

        public RecipeController(RecipeManagementContext context)
        {
            _context = context;
        }
        //GET RECIPE controller
        public IActionResult Index()
        {
            List<RecipeModel> recipes = _context.Recipes.ToList();
            return View(recipes);
        }
        //GET recipe/Details/{id}
        public IActionResult Details(int id)
        {
            RecipeModel recipe = _context.Recipes.Find(id);
            
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }
        //GET recipe/Create
        public IActionResult Create()
        {
            return View();
        }
        //POST recipe/Create
        [HttpPost]
        public IActionResult Create(RecipeModel recipe)
        {
            if (ModelState.IsValid) //Checks to make sure [Required] [StringLength(50)] are all valid in input
            {
                _context.Recipes.Add(recipe); //Add to db what the user entered
                _context.SaveChanges(); //Update the database
                return RedirectToAction("Index"); //Clicking create will send you back to the list of recipes
            }
            return View(recipe);
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
        //PUSH recipe/edit/{id}
        [HttpPost]
        public IActionResult Edit(int id, RecipeModel recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(recipe).State = EntityState.Modified;
            }
            return View();
        }

        //Delete recipe/delete/{id}
        
        public IActionResult Delete(int id)
        {
            RecipeModel recipe = _context.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (_context.Recipes == null)
            {
                return Problem("Recipe is null");
            }
            RecipeModel recipe = _context.Recipes.Find(id);
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
