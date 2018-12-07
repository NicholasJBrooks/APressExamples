using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ConfiguringApps.Infrastructure;
using Microsoft.Extensions.Logging; 

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UpTimeService uptime;
        private ILogger<HomeController> logger;

        public HomeController(UpTimeService up, ILogger<HomeController> log)
        {
            logger = log; 
            uptime = up;
        } 

        public ViewResult Index(bool throwException = false)
        {
            logger.LogDebug($"Handled {Request.Path} at uptime {uptime.UpTime}");

            if (throwException)
            {
                throw new System.NullReferenceException();
            }
            return View(new Dictionary<string, string>
            {
                ["Message"] = "This is the Index action",
                ["Uptime"] = $"{uptime.UpTime}ms"
            });
        }

        public ViewResult Error() => View(nameof(Index),
            new Dictionary<string, string>
            {
                ["Message"] = "This is the Error action"
            });
    }
}