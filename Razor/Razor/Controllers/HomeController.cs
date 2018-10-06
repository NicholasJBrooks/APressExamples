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
            Product myProduct = new Product()
            {
                ProductId = 1,
                Name = "Kayak",
                Description = "A boat for one person",
                Category = "Watersports",
                Price = 275m
            };
            /// Sending more info to the view he recmmends using this for giving the view hints on how to display the data and not data that will be shown to the user
            /// Accessed with @ViewBag.VariableName
            ViewBag.StockLevel = 2; 
            return View(myProduct);
        }
    }
}