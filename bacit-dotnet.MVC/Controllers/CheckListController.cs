using bacit_dotnet.MVC.Models.CheckList;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers;

public class CheckListController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Save(CheckListViewModel model) {
        if(ModelState.IsValid)
        {
            var s = "ineedabreakpoint";

        }
        return View("Index", model);
    }
}