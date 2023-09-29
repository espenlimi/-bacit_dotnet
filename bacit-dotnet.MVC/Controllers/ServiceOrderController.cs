using bacit_dotnet.MVC.Models.ServiceOrdre;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers
{
    public class ServiceOrderController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            var model = new ServiceOrderViewModel
            {
                ConsumedHours = 0,
                CreatedDate = new DateTime(2023, 9,7),
                CustomerCity="Kristiansand",
                CustomerComment="Hei og hå, jeg er en kundekommentar",
                CustomerEmail="customer@thesystem.no",
                CustomerName="Sattosk Rev",
                CustomerStreet="Gata 13",
                CustomerTelephoneNumber="1337",
                CustomerZipcode="1234",
                FutureMaintenance="Ingenting å bemerke",
                ImageUrl="",
                IsAdministrator=false,
                JobGroups = new List<ServiceOrderJobGroupModel> { 
                    new ServiceOrderJobGroupModel {Name ="Mekanisk", Jobs=new List<string>{"Skru på ting", "Bytte slureflapp"} },
                    new ServiceOrderJobGroupModel{ Name="Elektrisk", Jobs=new List<string>{"Sikringer","Greier" } },
                    
                
                },
                Mechanic="Espen",
                MechanicComment="ingen kommentar",
                SerialNumber="pirepioj123åojå",
                ServiceOrderId = 1
            };

            return View(model);
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
}
