using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers;

public class SignOutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}