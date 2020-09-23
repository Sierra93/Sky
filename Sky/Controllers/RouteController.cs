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

        // Метод переходит на главную страницу.
        [Route("index")]
        public IActionResult OnRouteMain() {
            return View("Index");
        }

        // Метод переходит на страницу обо мне.
        [Route("about-me")]
        public IActionResult AboutMe() {
            return View();
        }

        // Метод переходит на страницу описания услуги.
        [Route("order-details")]
        public IActionResult GetOrderDetails() {
            return View();
        }
    }
}
