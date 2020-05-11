using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Demo.Models.User;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers.User
{
    public class LoginController : Controller
    {
        private readonly UserService userService;
        public LoginController()
        {
            userService = new UserService();
        }
        public IActionResult Index()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            string username = model.UserName;
            string password = model.Password;
            UserEntity user = userService.GetMatchedUser(username, password);
            if (user != null)
            {
                ViewData["UserName"] = username;
                return View("Succeed");
            }
            ModelState.AddModelError("", "No such username or password does not match to username");
            return View(model);
        }
    }
}