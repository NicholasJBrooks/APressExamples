using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using LanguageFeatures.Models;
namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var products = new []
            {
                new  {Name = "kayak", Price = 275m },
                new  {Name = "lifejacket", Price = 48.95m },
                new  {Name = "soccer ball", Price = 19.50m },
                new  {Name = "corner flag", Price = 34.95m },
            };

            return View(products.Select(x => $"{nameof(x.Name)}: {x.Name}, {nameof(x.Price)}: {x.Price}"));
        }
        
    }
}



///  Product[] productArray =
//            {
//                new Product {Name = "Kayak", Price = 275M },
//                new Product {Name = "Lifejacket", Price = 48.95M },
//                new Product {Name = "Soccer Ball", Price = 19.50M },
//                new Product {Name = "Corner Flag", Price = 34.95M },
//            };

//            decimal priceFilterTotal = productArray.Filter(x => (x?.Price ?? 0) >= 20).TotalPrices();
//decimal nameFilterTotal = productArray.Filter(x => x?.Name?[0] == 'S').TotalPrices();

//            return View("Index", new string[] { $"Price Total: {priceFilterTotal:C2}", $"Name Total: {nameFilterTotal:C2}" }); 
//        }

    /// This is the use of the lamda functions and how if you just have areturn statement you dont need the body just like below.
//public ViewResult Index() =>
        //View(Product.GetProducts().Select(x => x?.Name));