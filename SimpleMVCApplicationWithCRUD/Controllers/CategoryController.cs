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
        // the Get action Method,
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
            //custom validation first
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot be same as Name.");
            }
            //create serverside validation
            if (ModelState.IsValid) 
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index"); // this will redirect the user to the index page after saving the changes
            }
            //serverside validation end
            return View(obj);
        }

        //this is for the edit action
        // 
        // the Get action Method,
        public IActionResult Edit(int? id) //retrieve int based on id and use it to dislay the requested category item
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //now, create a post method to use to submit the data sent from the create view form
        // because it is post, we have to write the attribute [HttpPost]
        // the Post Method,

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Edit(Category obj)
        {
            //custom validation first
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot be same as Name.");
            }
            //create serverside validation
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                TempData["success"] = "Category Updated Successfully";
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            //serverside validation end
            return View(obj);
        }


        //Delete action

        // the Get action Method,
        public IActionResult Delete(int? id) //retrieve int based on id and use it to dislay the requested category item
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //now, create a post method to use to submit the data sent from the create view form
        // because it is post, we have to write the attribute [HttpPost]
        // the Post Method,

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int? id) // we cannot use the Delete word here
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
            }
            
        }
    }

