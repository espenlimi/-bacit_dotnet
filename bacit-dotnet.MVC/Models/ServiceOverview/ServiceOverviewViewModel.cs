namespace bacit_dotnet.MVC.Models.ServiceOverview
{
    public class ServiceOverviewViewModel
    {
        public int ID { get; set; }
        public string Ordrenummer { get; set; }
        public DateTime Dato { get; set; }
        public string Kunde { get; set; }
        public string Status { get; set; }
    }

}
