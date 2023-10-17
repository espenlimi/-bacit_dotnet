namespace bacit_dotnet.MVC.Models.ServiceOrder
{
    public class ServiceOrderViewModel
    {
        public int Ordrenummer { get; set; }
        public DateTime Dato { get; set; }
        public string Kunde { get; set; }
        public string Status { get; set; }
    }

}
