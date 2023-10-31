using Microsoft.AspNetCore.Mvc;
using bacit_dotnet.MVC.Models.ServiceForm;
using bacit_dotnet.MVC.Repositories;

namespace bacit_dotnet.MVC.Controllers
{
    public class ServiceOrderController : Controller
    {
        private readonly ServiceFormRepository _repository;

        public ServiceOrderController(ServiceFormRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var serviceFormEntry = _repository.GetSomeOrderInfo();
            return View(serviceFormEntry);
        }
    }
}