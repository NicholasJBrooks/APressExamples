using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Razor.Model;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Product[] array =
            {
                new Product {Name = "Kayak", Price = 275m },
                new Product {Name = "Lifejacket", Price = 48.95m },
                new Product {Name = "Soccer Ball", Price = 19.50m },
                new Product {Name = "Corner Flag", Price = 34.95m }
         };
            return View(array);
        }
    }
}



// Sending more info to the view he recmmends using this for giving the view hints on how to display the data and not data that will be shown to the user
// Accessed with @ViewBag.VariableName
//ViewBag.StockLevel = 2; 