using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Models.Users;
using bacit_dotnet.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace bacit_dotnet.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository userRepository;
        private readonly ISqlConnector sqlConnector;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, ISqlConnector sqlConnector)
        {
            _logger = logger;
            this.userRepository = userRepository;
            this.sqlConnector = sqlConnector;
        }

        [HttpGet]
        public IActionResult UserData()
        {
            var data = sqlConnector.GetUsers();
            var model = new UserViewModel();
            model.Users = data;
            return View("Users", model);
        }
        

        [HttpGet]
        public IActionResult Index()
        {
            var model = new RazorViewModel
            {
                Content = "Jeff"
            };
            return View("Index", model);
        }
    }
}