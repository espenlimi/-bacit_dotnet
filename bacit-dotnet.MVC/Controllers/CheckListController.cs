using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers;

public class CheckListController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}