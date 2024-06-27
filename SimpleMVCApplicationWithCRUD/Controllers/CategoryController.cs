using Microsoft.AspNetCore.Mvc;
using SimpleMVCApplicationWithCRUD.Data;
using SimpleMVCApplicationWithCRUD.Models;

namespace SimpleMVCApplicationWithCRUD.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MyDbContext _db;
        //tell application to use dbcontext while connection to db is made
        public CategoryController(MyDbContext db)
        {
           _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        // create the create action method for the new category button
        // the Get Method,
        public IActionResult Create()
        {
            return View();
        }

        //now, create a post method to use to submit the data sent from the create view form
        // because it is post, we have to write the attribute [HttpPost]
        // the Post Method,

        [HttpPost]
        [ValidateAntiForgeryToken] // this will prevent cross site request forgery attack
        public IActionResult Create(Category obj)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index"); // this will redirect the user to the index page after saving the changes
        }

    }
}
