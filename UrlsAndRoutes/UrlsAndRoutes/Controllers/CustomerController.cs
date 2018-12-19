﻿using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models; 

namespace UrlsAndRoutes.Controllers
{
    public class CustomerController : Controller
    {
        public ViewResult Index() => View("Result",
            new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(Index)
            });

        public ViewResult List(string id)
        {
            Result result = new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(List)
            };

            result.Data["Id"] = id ?? "<no value>";
            result.Data["catchall"] = RouteData.Values["catchall"];
            return View("Result", result); 
        }
    }


}
