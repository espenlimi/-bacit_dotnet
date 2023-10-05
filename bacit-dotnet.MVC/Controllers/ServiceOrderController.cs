using bacit_dotnet.MVC.Models.ServiceOrder;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers
{
    public class ServiceOrderController : Controller
    {
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
                    new ServiceOrderJobGroupModel {Name="Elektrisk", Jobs=new List<string>{"Sikringer","Greier" } },
                    new ServiceOrderJobGroupModel {Name="Hydraulisk", Jobs = new List<string>{"Rør", "Olje"} }
                    
                
                },
                Mechanic="Espen",
                MechanicComment="ingen kommentar",
                SerialNumber="pirepioj123åojå",
                ServiceOrderId = 1
            };

            return View(model);
        }
    }
}
