using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Buisness.Services;
using Buisness.ViewModels;

namespace Stores.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserServise _userServices;
        public UserController(UserServise userService)
        {
            _userServices = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Auth()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Auth(string userName,string password)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _userServices.GetUser(userName,password);
            ViewBag.IsAuthorize = true;
            return View(result);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Register(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _userServices.AddUser(model);
            return View(result);
        }
    }
}
