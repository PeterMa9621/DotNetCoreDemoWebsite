using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models.User;
using Demo.Services;
using Demo.Util;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers.User
{
    public class RegisterController : Controller
    {
        private readonly UserService userService;
        public RegisterController()
        {
            userService = new UserService();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([Bind("UserName,Password,Ip,LastLogin,RegDate,RegIp,Email,Session")] UserEntity userEntity)
        {
            if(ModelState.IsValid)
            {
                string ipAddress = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                bool succeed = userService.Add(userEntity, ipAddress);
                if (succeed)
                    return RedirectToAction("Index", "Home");
                else
                    return RedirectToAction("Error", "Home");
            } else
            {
                return RedirectToAction("Error", "Home");
            }
            
        }
    }
}