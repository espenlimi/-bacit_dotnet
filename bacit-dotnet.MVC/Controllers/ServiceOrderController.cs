using bacit_dotnet.MVC.Models.ServiceOrdre;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Xml.Linq;

namespace bacit_dotnet.MVC.Controllers
{
    public class ServiceOrderController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Overview()
        {
            return View();
        }

        public IActionResult Checklist()
        {
            return View();
        }

        public IActionResult WorkDocument()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
      
        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [HttpGet]
       
        public IActionResult Index(string FirstName, string LastName, string PhoneNumber, string Email, string ProductName, string ProductType, string PreferredTimePeriod, string Comment)
        {
            var model = new ServiceOrderViewModel
            {
                FirstName = HttpUtility.HtmlEncode(FirstName),
                LastName = HttpUtility.HtmlEncode(LastName),
                PhoneNumber = HttpUtility.HtmlEncode(PhoneNumber),
                Email = HttpUtility.HtmlEncode(Email),
                ProductName = HttpUtility.HtmlEncode(ProductName),
                PreferredTimePeriod = HttpUtility.HtmlEncode(PreferredTimePeriod),
                Comment = HttpUtility.HtmlEncode(Comment)

            };

            return View(model);
        }

        [HttpPost]
        [HttpGet]
        public IActionResult CreateWorkDocument(string Order, string Week, string Inquiry, bool CaseCompleted, string CustomerInfo, DateTime? PlannedDelivery, DateTime? ProductReceivedDate, DateTime? AgreedCompletionDate, DateTime? ServiceCompletedDate, string ServiceHours, bool HasOrderNumber, bool HasServiceForm)
        {
            var model = new WorkDocumentViewModel
            {
                Order = HttpUtility.HtmlEncode(Order),
                Week = HttpUtility.HtmlEncode(Week),
                Inquiry = HttpUtility.HtmlEncode(Inquiry),
                CaseCompleted = CaseCompleted,
                CustomerInfo = HttpUtility.HtmlEncode(CustomerInfo),
                PlannedDelivery = PlannedDelivery,
                ProductReceivedDate = ProductReceivedDate,
                AgreedCompletionDate = AgreedCompletionDate,
                ServiceCompletedDate = ServiceCompletedDate,
                ServiceHours = HttpUtility.HtmlEncode(ServiceHours),
                HasOrderNumber = HasOrderNumber,
                HasServiceForm = HasServiceForm
            };
            return View(model);
        }

        [HttpPost]
        [HttpGet]
        public IActionResult CreateChecklist(string? Kategorier, string? Sjekkpunkter, bool OK, bool BørSkiftes, bool Defekt)
        {
            var model = new ChecklistViewModel
            {
                Kategorier = Kategorier,
                Sjekkpunkter = Sjekkpunkter,
                OK = OK,
                BørSkiftes = BørSkiftes,
                Defekt = Defekt
            };

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(ServiceOrderViewModel model) {
            if(ModelState.IsValid)
            {
                var s = "ineedabreakpoint";

            }
            return View("Index", model);
        }
    }
}
