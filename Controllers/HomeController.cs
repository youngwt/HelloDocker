using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloDocker.Models;
using Microsoft.Extensions.Configuration;

namespace HelloDocker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repository;
        private string _message;

        public HomeController(
            ILogger<HomeController> logger, 
            IRepository repository,
            IConfiguration config)
        {
            _logger = logger;
            _repository = repository;
            _message = config["Message"] ?? "Hello Docker";
        }

        public IActionResult Index()
        {
            ViewBag.Message = _message;
            return View(_repository.Products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
