using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers
{
    public class SuggestionController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISuggestionRepository suggestionRepository;

        public SuggestionController(ILogger<HomeController> logger, ISuggestionRepository suggestionRepository)
        {
            _logger = logger;
            this.suggestionRepository = suggestionRepository;
        }

        public IActionResult Index()
        {
            SuggestionViewModel model = new SuggestionViewModel();
            model.suggestions = suggestionRepository.getAll();
            return View(model);
        }
    }
}
