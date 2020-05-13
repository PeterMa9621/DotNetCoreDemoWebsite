using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models.DataModel.User;
using Demo.Models.ViewModel;
using Demo.Services;
using Demo.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers.User
{
    public class RegisterController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly UserService userService;
        public RegisterController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            userService = new UserService(_userManager, signInManager);
        }
        public IActionResult Index()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                string ipAddress = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                model.RegIp = ipAddress;
                bool succeed = await userService.Add(model);
                if (succeed)
                    return RedirectToAction("Index", "Login");
                ModelState.AddModelError("", "The username has already been taken");
            }
            
            return View(model);
        }
    }
}