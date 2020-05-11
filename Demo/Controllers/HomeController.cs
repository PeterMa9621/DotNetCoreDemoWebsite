using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Demo.Models;
using Demo.Services;
using Demo.Models.Repository;
using Demo.Models.User;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserRepository userRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            userRepository = new UserRepository();
            _logger = logger;
        }

        public IActionResult Index()
        {
            this.userRepository.Add(new UserEntity() {
                UserName = "Test2",
                Password = "123456",
                Ip = "127.0.0.1",
                RegDate = 1588803544649
                });
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
