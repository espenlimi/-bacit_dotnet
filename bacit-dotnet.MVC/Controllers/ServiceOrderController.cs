using bacit_dotnet.MVC.Models.ServiceOrder;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers
{
    public class ServiceOrderController : Controller
    {
        public IActionResult Index()
        {
         //Oppprettet instanse 
            var model = new ServiceOrderViewModel
            {
                BrukteTimer = 0,
                Opprettelsesdato = new DateTime(2023, 9,27),
                CustomerCity="Kristiansand",
                Kundekommentar= "Hei og hå, jeg er en kundekommentar",
                CustomerEmail="customer@thesystem.no",
                CustomerName="Sattosk Rev",
                CustomerStreet="Gata 13",
                CustomerTelephoneNumber="1337",
                CustomerZipcode="1234",
                FutureMaintenance="Ingenting å bemerke",
                ImageUrl="",
                IsAdministrator=false,
                OrderGroups = new List<ServiceOrderGroupModel> { 
                    new ServiceOrderGroupModel {Name ="Mekanisk", Orders = new List<string>{"reperasjon"} },
                
                },
                Mekanikker= "Espen",
                MekanikkerKommentar= "ingen kommentar",
                Ordrenummer= "pirepioj123åojå",
                ServiceOrderId = 1
            };

            return View(model);
        }
    }
}
