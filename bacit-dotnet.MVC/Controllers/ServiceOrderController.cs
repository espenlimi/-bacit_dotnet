using bacit_dotnet.MVC.Models.ServiceOrder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace bacit_dotnet.MVC.Controllers;

public class ServiceOrderController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Save(ServiceOrderViewModel model) {
        if(ModelState.IsValid)
        {
            var s = "ineedabreakpoint";

        }
        return View("Index", model);
    }
}