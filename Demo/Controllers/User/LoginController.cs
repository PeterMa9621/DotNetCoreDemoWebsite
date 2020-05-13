using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Demo.Models.DataModel.User;
using Demo.Models.ViewModel;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ubiety.Dns.Core.Records;

namespace Demo.Controllers.User
{
    public class LoginController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly UserService userService;
        public LoginController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            userService = new UserService(_userManager, signInManager);
        }
        public IActionResult Index()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            string username = model.UserName;
            string password = model.Password;

            //model.ReturnUrl = returnurl;
            bool result = await userService.SignIn(username, password);
            if (result)
            {
                ViewData["UserName"] = username;
                return View("Succeed");
            }
            ModelState.AddModelError("", "No such username or password does not match to username");
            return View(model);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            userService.SignOut();
            return RedirectToAction("Index");
        }
    }
}