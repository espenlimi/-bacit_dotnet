using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace bacit_dotnet.MVC.Controllers;

public class RegisterController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}