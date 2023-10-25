using Microsoft.AspNetCore.Mvc;
using bacit_dotnet.MVC.Models.ServiceForm;
using bacit_dotnet.MVC.Repositories;

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
    }
}