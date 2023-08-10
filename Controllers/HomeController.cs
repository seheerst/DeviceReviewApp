using DeviceReviewApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
                products = products.Where(p => p.Name.ToLower().Contains(searchString)).ToList();
            }

            if (!String.IsNullOrEmpty(category) && int.Parse(category) != 0)
            {
                products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
            }

            ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId", "Name", category);
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}