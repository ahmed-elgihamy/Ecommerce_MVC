
using Bookoria.DataAccess.Repository.IRepository;
using Bookoria.DataAcess.Data;
using Bookoria.Models;
using Ecommerce_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace Ecommerce_MVC.Areas.Admin.Controllers
{

         [Area("Admin")]
    public class ProductController:Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unit ,IWebHostEnvironment webHostEnvironment )
        {
            _webHostEnvironment = webHostEnvironment;
            _unit = unit;
        }
        public IActionResult Index()
        {
            var products = _unit.Product.GetAll( includeProperties:"Category").ToList();
            return View(products);
        }

        public IActionResult Upsert(int ? id) //Updateinsert
        {
      
            ProductVM productvm = new ProductVM()
            {
                CategoryLists = _unit.Category.GetAll().Select(u => new SelectListItem()
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                product = new Product()
            };
            if (id == null || id == 0)
            {
                return View(productvm);
            }
            else
            {
                productvm.product = _unit.Product.Get(d => d.Id == id);

                return View(productvm);
            }


        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productvm ,IFormFile ?file)
        {
            //  ModelState.AddModelError("Name", "dljfkdjfdjfjdlf");

            if (ModelState.IsValid)
            {

                    string wwwRootPath = _webHostEnvironment.WebRootPath;
            
                    if (file != null)
                    {

                    if (!string.IsNullOrEmpty(productvm.product.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, productvm.product.ImageUrl.TrimStart('\\'));

                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                    }
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath = Path.Combine(wwwRootPath, @"images\product");

                        using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                         productvm.product.ImageUrl = @"\images\product\" + fileName;
                    }

                    if(productvm.product.Id==0)
                    {

                    _unit.Product.Add(productvm.product);
                    }
                    else
                    {
                    _unit.Product.Update(productvm.product);
                    }
                
                _unit.SaveChanges();
                TempData["success"] = "Product Created successfully";
                return RedirectToAction("index", "Product");
            }
            else
            {
                productvm.CategoryLists = _unit.Category.GetAll().Select(u => new SelectListItem()
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });


                return View(productvm);
            }
        }



        //public IActionResult Edit(int id)
        //{
        //   if(id==null ||id==0)
        //    {
        //        return NotFound();
        //    }
        //    var Product = _unit.Product.Get(d => d.Id == id);
        //    if (Product ==null)
        //    {
        //        return NotFound();
        //    }
        //    return View(Product);
        //}

        //[HttpPost]
        //public IActionResult Edit(Product product)
        //{


        //    //  ModelState.AddModelError("Name", "dljfkdjfdjfjdlf");

        //    if (ModelState.IsValid)
        //    {

        //        _unit.Product.Update(product);
        //        _unit.SaveChanges();
        //        TempData["success"] = "Product Updated successfully";
        //        return RedirectToAction("index", "Product");
        //    }

        //    return View(product);
        //}


        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var Product = _unit.Product.Get(d => d.Id == id);
        //    if (Product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(Product);
        //}

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    var Product = _unit.Product.Get(d => d.Id == id);

        //    if (Product == null)
        //    {
        //        return NotFound();
        //    }

        //    _unit.Product.Remove(Product);
        //    TempData["success"] = "Product Deleted successfully";
        //    _unit.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        //=======================================
        [HttpGet]
        public IActionResult Getall()
        {
            var products = _unit.Product.GetAll(includeProperties: "Category").ToList();

            return Json(new {data=products});
        }


  

        [HttpDelete]
        public IActionResult Delete(int ?id)
        {
            var product = _unit.Product.Get(d => d.Id == id);

            if (product == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            if (!string.IsNullOrEmpty(product.ImageUrl))
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, product.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
            _unit.Product.Remove(product);
            _unit.SaveChanges();
            return Json(new { success = true, message = "Product Deleted successfully" });


        }

    }
}
