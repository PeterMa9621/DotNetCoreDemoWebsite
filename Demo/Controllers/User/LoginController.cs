using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection data)
        {
            string username = data["username"];
            string password = data["password"];
            UserEntity user = userService.GetMatchedUser(username, password);
            if (user != null)
            {
                ViewData["UserName"] = username;
                return View("Succeed");
            } else
            {
                return View("Failed");
            }
        }
    }
}