using Microsoft.AspNetCore.Mvc;
using bacit_dotnet.MVC.Models;

namespace bacit_dotnet.MVC.Controllers
{
    public class ServiceOverviewController : Controller
    {
        private readonly PersonRepository _repository;

        public ServiceOverviewController(PersonRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var ReficioDB = _repository.GetAll();
            return View(ReficioDB);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }
    }
}