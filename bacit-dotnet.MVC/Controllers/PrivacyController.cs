using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers;

public class PrivacyController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}