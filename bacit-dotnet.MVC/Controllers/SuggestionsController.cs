using bacit_dotnet.MVC.Models.Suggestions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers
{

    public class SuggestionsController : Controller
    {
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetStuff()
        {

            return View("Index");
        }

        [HttpPost]
        public IActionResult Save(SuggestionViewModel model)
        {
            if (!ModelState.IsValid)
                throw new Exception("Dette gikk dårlig");
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException();
            return null;
        }
    }
}
