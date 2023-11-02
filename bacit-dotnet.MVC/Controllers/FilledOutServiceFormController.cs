using Microsoft.AspNetCore.Mvc;
using bacit_dotnet.MVC.Repositories;

namespace bacit_dotnet.MVC.Controllers;

public class FilledOutServiceFormController : Controller
{
    private readonly ServiceFormRepository _repository;

    public FilledOutServiceFormController(ServiceFormRepository repository)
    {
        _repository = repository;
    }
    
    public IActionResult Index()
    {
        var serviceFormEntry = _repository.GetSomeOrderInfo();
        return View(serviceFormEntry);
    }
}