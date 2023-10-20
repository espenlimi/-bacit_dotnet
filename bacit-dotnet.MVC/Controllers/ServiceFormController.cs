using Microsoft.AspNetCore.Mvc;
using bacit_dotnet.MVC.Models.ServiceForm;

namespace bacit_dotnet.MVC.Controllers
{
    public class ServiceFormController : Controller
    {
        private readonly ServiceFormRepository _repository;

        public ServiceFormController(ServiceFormRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ServiceFormEntry serviceFormEntry)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(serviceFormEntry);
                return RedirectToAction("Index", "ServiceOrdre");
            }
            return View(serviceFormEntry);
        }
        
    }
}