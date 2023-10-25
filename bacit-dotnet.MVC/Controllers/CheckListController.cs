using bacit_dotnet.MVC.Models.CheckList;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers;

public class CheckListController : Controller
{
    [HttpGet]
    [ValidateAntiForgeryToken]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Save(CheckListViewModel model) {
        if(ModelState.IsValid)
        {
            var s = "ineedabreakpoint";

        }
        return View("Index", model);
    }
}