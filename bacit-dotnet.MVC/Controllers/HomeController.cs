using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Repositories;
using bacit_dotnet.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace bacit_dotnet.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository employeeRepository;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository userRepository)
        {
            _logger = logger;
            this.employeeRepository= userRepository;
        }

        public IActionResult Index()
        {
            EmployeeViewModel model = new EmployeeViewModel();
            model.employees = employeeRepository.GetAll();
            return View(model);
        }
    }
}