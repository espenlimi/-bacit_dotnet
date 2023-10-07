using System.Runtime.InteropServices.JavaScript;
namespace bacit_dotnet.MVC.Models.ServiceOrder
{
    public class ServiceOrderViewModel
    {
        public string Mekanikker { get; set; }
        public bool IsAdministrator { get; set; }
        public string Ordrenummer { get; set; }
        public DateTime Opprettelsesdato { get; set; }
        public decimal BrukteTimer { get; set; }
        public string ImageUrl { get; set; }
        public string MekanikkerKommentar { get; set; }
        public string Kundekommentar { get; set; }

        public string FutureMaintenance { get; set; }
        public int ServiceOrderId { get; set; }
        public List<ServiceOrderGroupModel> OrderGroups { get; set; }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerZipcode { get; set; }
        public string CustomerTelephoneNumber { get; set; }

    }
  
    public class ServiceOrderGroupModel
    {
        public string Name { get; set; }

        public List<string> Orders { get; set; }
    }

}
