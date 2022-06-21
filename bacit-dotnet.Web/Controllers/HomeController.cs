using bacit_dotnet.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.Web.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [Route("StaticText")]
        public IActionResult Static()
        {
            return new ContentResult() { Content = "<html><head><title>BACIT</title></head><body><h1>En time til ørsta rådhus</h1></body> </html>", ContentType = "text/html; charset=UTF-8" };
        }

        [Route("TemplateText")]
        public IActionResult WithPageTemplate()
        {
            var model = new DemoPageModel
            {
                Content = "En time til ørsta rådhus"
            };
            return View("DemoView", model);
        }
    }
}
