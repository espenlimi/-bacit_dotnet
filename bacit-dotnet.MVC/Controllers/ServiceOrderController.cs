using Microsoft.AspNetCore.Mvc;
using bacit_dotnet.MVC.Models;

namespace bacit_dotnet.MVC.Controllers
{
    public class ServiceOrderController : Controller
    {
        private readonly PersonRepository _repository;

        public ServiceOrderController(PersonRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var people = _repository.GetAll();
            return View(people);
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