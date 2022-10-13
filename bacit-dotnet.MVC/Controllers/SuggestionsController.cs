using bacit_dotnet.MVC.Models.Suggestions;
using Microsoft.AspNetCore.Mvc;
using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Models;

namespace bacit_dotnet.MVC.Controllers
{
    public class SuggestionsController : Controller
    {
        private readonly ILogger<SuggestionsController> _logger;
        private readonly ISqlConnector sqlConnector;

        public SuggestionsController(ILogger<SuggestionsController> logger, ISqlConnector sqlConnector)
        {
            _logger = logger;
            this.sqlConnector = sqlConnector;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(SuggestionViewModel model) 
        {
            sqlConnector.SetSuggestionsParam(model);
            return View(model);
        }
        [HttpGet]
        public IActionResult ViewSug()
        {

            var data = sqlConnector.FetchSug();
            var model = new SuggestionModel();
            model.Sug = data;

            return View(model);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var data = sqlConnector.FetSpeSug(id);
            var model = new SuggestionModel();
            model.Sug = data;

            return View(model);
        }

        [HttpPost]
        public IActionResult EditSave(SuggestionViewModel model, int id)
        {
            sqlConnector.UpdateValueSetSug(model, id);
            return View("Save",model);
        }
    }
}
