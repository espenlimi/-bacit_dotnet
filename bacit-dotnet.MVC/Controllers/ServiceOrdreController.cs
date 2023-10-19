using Microsoft.AspNetCore.Mvc;
using bacit_dotnet.MVC.Models.ServiceForm;

namespace bacit_dotnet.MVC.Controllers
{
    public class ServiceOrdreController : Controller
    {
        private readonly ServiceFormRepository _repository;

        public ServiceOrdreController(ServiceFormRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var serviceFormEntry = _repository.GetAll();
            return View(serviceFormEntry);
        }

        // Other service ordre related actions can be added here
    }
}