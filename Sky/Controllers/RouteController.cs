using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sky.Models;

namespace Sky.Controllers {
    public class RouteController : Controller {
        public IActionResult Index() { 
            return View();
        }

        [Route("index")]
        public IActionResult OnRouteMain() {
            return View("Index");
        }

        [Route("about-me")]
        public IActionResult AboutMe() {
            return View();
        }
    }
}
