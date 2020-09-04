using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Stores.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.IsAuthorize = false;
            return View();
        }

        public IActionResult RedirectToAuth()
        {
            return RedirectToAction("Auth","User");
        }
        public IActionResult RedirectToRegister()
        {
            return RedirectToAction("Register","User");
        }
    }
}
