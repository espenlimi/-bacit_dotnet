using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers;

public class ServiceFormController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
