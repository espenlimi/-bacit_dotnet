using bacit_dotnet.MVC.Models.CheckList;
using Microsoft.AspNetCore.Mvc;
using bacit_dotnet.MVC.Repositories;

namespace bacit_dotnet.MVC.Controllers
{
    public class CheckListController : Controller
    {
        private readonly CheckListRepository _repository;

        public CheckListController (CheckListRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CheckListViewModel checkListViewModel)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(checkListViewModel);
                return RedirectToAction("Index", "CheckList");
            }
            
            return View(checkListViewModel);
        }
        
    }
}