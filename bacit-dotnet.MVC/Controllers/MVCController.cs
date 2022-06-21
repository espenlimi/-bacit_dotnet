using bacit_dotnet.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace bacit_dotnet.MVC.Controllers
{
    public class MVCController : Controller
    {
        private readonly ILogger<MVCController> _logger;

        public MVCController(ILogger<MVCController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return new ContentResult() { Content = "<html><head><title>BACIT</title></head><body><h1>En time til ørsta rådhus</h1></body> </html>", ContentType = "text/html; charset=UTF-8" };
        }

        public IActionResult UsingRazor()
        {
            var model = new RazorViewModel
            {
                Content = "En time til ørsta rådhus"
            };
            return View("UsingRazor", model);
        }
    }
}