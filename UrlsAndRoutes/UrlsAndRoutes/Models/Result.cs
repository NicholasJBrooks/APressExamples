﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlsAndRoutes.Models
{
    public class Result
    {
        public string Controller { get; set; }

        public string Action { get; set; }

        public Dictionary<string, Object> Data { get; }
        = new Dictionary<string, object>();
    }
}
