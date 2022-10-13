using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace bacit_dotnet.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISqlConnector sqlConnector;

        public HomeController(ILogger<HomeController> logger, ISqlConnector sqlConnector)
        {
            _logger = logger;
            this.sqlConnector = sqlConnector;
        }

        [HttpGet]
        public IActionResult UserData()
        {

            var data = sqlConnector.GetUsers();
            var model = new UsersModel();
            model.Users = data;
            return View("Users", model);

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}