using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCPractice.Data;
using MVCPractice.Models;

namespace MVCPractice.Controllers
{
    public class AuthorController : Controller
    {
        private readonly RecipeManagementContext _context;

        public AuthorController(RecipeManagementContext context)
        {
            _context = context;
        }
        //GET RECIPE controller
        public IActionResult Index()
        {
            List<AuthorModel> authors = _context.Authors.ToList();
            return View(authors);
        }
        //GET recipe/Details/{id}
        public IActionResult Details(int id)
        {
            AuthorModel author = _context.Authors.Find(id);

            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        //GET recipe/Create
        public IActionResult Create()
        {
            return View();
        }
        //POST recipe/Create
        [HttpPost]
        public IActionResult Create(AuthorModel author)
        {
            if (ModelState.IsValid) //Checks to make sure [Required] [StringLength(50)] are all valid in input
            {
                _context.Authors.Add(author); //Add to db what the user entered
                _context.SaveChanges(); //Update the database
                return RedirectToAction("Index"); //Clicking create will send you back to the list of recipes
            }
            return View(author);
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
        //PUSH recipe/edit/{id}
        [HttpPost]
        public IActionResult Edit(int id, AuthorModel author)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(author).State = EntityState.Modified;
            }
            return View();
        }

        //DELETE recipe/delete/{id}

        public IActionResult Delete(int id)
        {
            AuthorModel author = _context.Authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (_context.Authors == null)
            {
                return Problem("Author is null");
            }
            AuthorModel author = _context.Authors.Find(id);
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
