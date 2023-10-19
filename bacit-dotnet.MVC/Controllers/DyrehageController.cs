using bacit_dotnet.MVC.Entities;
using bacit_dotnet.MVC.Models.Dyrehage;
using bacit_dotnet.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers
{
    public class DyrehageController : Controller
    {
        private readonly IDyrRepository _dyrRepository;

        public DyrehageController(IDyrRepository dyrRepository)
        {
            _dyrRepository = dyrRepository;
        }
        public IActionResult Index()
        {
            var model = new DyrFullViewModel();
            model.DyrList = _dyrRepository.GetAll().Select(x => new DyrViewModel { Id = x.Id, Name = x.Name }).ToList();

            return View("Index",model);
        }

        public IActionResult Post(DyrFullViewModel dyr)
        {
            var entity = new Dyr
            {
                Id = dyr.UpsertModel.Id,
                Name = dyr.UpsertModel.Name,
            };
            _dyrRepository.Upsert(entity);
            return Index();
        }
    }
}
