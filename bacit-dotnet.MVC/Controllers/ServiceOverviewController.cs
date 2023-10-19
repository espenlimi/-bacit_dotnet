using bacit_dotnet.MVC.Models.ServiceOverview;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace bacit_dotnet.MVC.Controllers;

public class ServiceOverviewController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Save(ServiceOverviewViewModel model) {
        if(ModelState.IsValid)
        {
            var s = "ineedabreakpoint";

        }
        return View("Index", model);
    }
}