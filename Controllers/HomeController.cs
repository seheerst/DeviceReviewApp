using DeviceReviewApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeviceReviewApp.Controllers
{
    public class HomeController : Controller
    {
    
        public IActionResult Index(string searchString, string category)
        {
            var products = Repository.Products;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.SearchString = searchString;
                products = products.Where(p => p.Name!.ToLower().Contains(searchString)).ToList();
            }

            if (!String.IsNullOrEmpty(category) && int.Parse(category) != 0)
            {
                products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
            }

            // ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId", "Name", category);

            var model = new ProductViewModel()
            {
                Products = products,
                Categories = Repository.Categories,
                SelectedCategory = category
                    
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile imageFile)
        {
            var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };
            var extension = Path.GetExtension(imageFile.FileName);
            var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
            Console.WriteLine(randomFileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

            if (imageFile != null)
            {
                if (!allowedExtensions.Contains(extension))
               
                {
                    ModelState.AddModelError("", "Dosya formatı uygun değil");
                }
            }
            
            if (ModelState.IsValid)
            {

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                product.Image = randomFileName;
                Repository.CreateProduct(product);             
                return RedirectToAction("Index");              
            }
            ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId", "Name");
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);

            if (entity == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId", "Name");

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile? imageFile)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                   
                    var extension = Path.GetExtension(imageFile.FileName);
                    var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
                   
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    product.Image = randomFileName;
                }
                Repository.EditProduct(product);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId", "Name");

            return View(product);
        }
    }
    
    
}