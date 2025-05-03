
using Bookoria.DataAccess.Repository.IRepository;
using Bookoria.DataAcess.Data;
using Bookoria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ecommerce_MVC.Areas.Admin.Controllers
{

         [Area("Admin")]
    public class CategoryController:Controller
    {
        private readonly IUnitOfWork _unit;

        public CategoryController(IUnitOfWork unit )
        {
        
            _unit = unit;
        }
        public async Task<IActionResult> Index()
        {
            var cts = _unit.Category.GetAll();
            IEnumerable<SelectListItem> categorylist = _unit.Category.GetAll().Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.CategoryList = categorylist;

            return View(cts);
        }

        public IActionResult Create()
        {
            var cts = _unit.Category.GetAll().ToList();

            return View();
        }

        [HttpPost]
        public  IActionResult Create( Category catObj)
        {


          //  ModelState.AddModelError("Name", "dljfkdjfdjfjdlf");

            if (ModelState.IsValid)
            {

                _unit.Category.Add(catObj);
                _unit.SaveChanges();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("index", "Category");
            }

            return View(catObj);
        }

        public IActionResult Edit(int id)
        {
           if(id==null ||id==0)
            {
                return NotFound();
            }
            var category = _unit.Category.Get(d => d.Id == id);
            if (category ==null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category catObj)
        {


            //  ModelState.AddModelError("Name", "dljfkdjfdjfjdlf");

            if (ModelState.IsValid)
            {

                _unit.Category.Update(catObj);
                _unit.SaveChanges();
                TempData["success"] = "Category Updated successfully";
                return RedirectToAction("index", "Category");
            }

            return View(catObj);
        }

    
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unit.Category.Get(d => d.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _unit.Category.Get(d => d.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _unit.Category.Remove(category);
            TempData["success"] = "Category Deleted successfully";
            _unit.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
