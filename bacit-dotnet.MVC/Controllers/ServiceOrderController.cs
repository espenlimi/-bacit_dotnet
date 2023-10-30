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
                OrderId = 1,
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
