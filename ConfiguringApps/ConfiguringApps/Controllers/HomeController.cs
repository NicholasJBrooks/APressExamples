﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ConfiguringApps.Infrastructure;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UpTimeService uptime;

        public HomeController(UpTimeService up) => uptime = up; 

        public ViewResult Index() => View(new Dictionary<string, string>{
            ["Message"] = "This is the Index action",
            ["Uptime"] = $"{uptime.UpTime}ms"
        });
    }
}