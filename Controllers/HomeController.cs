using DeviceReviewApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeviceReviewApp.Controllers
{
    public class HomeController : Controller
    {
    

        public HomeController()
        {
       
        }

        public IActionResult Index()
        {
            return View(Repository.Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}