using Microsoft.AspNetCore.Mvc;
using bacit_dotnet.MVC.Models.ServiceForm;
using bacit_dotnet.MVC.Repositories;

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
        public IActionResult Index(ServiceFormViewModel serviceFormViewModel)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(serviceFormViewModel);
                return RedirectToAction("Index", "ServiceOrdre");
            }
            
            return View(serviceFormViewModel);
        }
        
    }
}