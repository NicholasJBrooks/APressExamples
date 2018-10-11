using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        SimpleRepository Repository = SimpleRepository.SharedRepository;

        [HttpGet]
        public IActionResult Index()
            => View(SimpleRepository.SharedRepository.Products.Where(x => x?.Price < 50));

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            Repository.AddProduct(product);
            return RedirectToAction("Index"); 
        }
    }
}