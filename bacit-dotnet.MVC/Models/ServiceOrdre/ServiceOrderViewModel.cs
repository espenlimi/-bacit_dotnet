namespace bacit_dotnet.MVC.Models.ServiceOrdre
{
    public class ServiceOrderViewModel
    {
        public string Mechanic { get; set; }
        public bool IsAdministrator { get; set; }
        public string SerialNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal ConsumedHours { get; set; }
        public string ImageUrl { get; set; }
        public string MechanicComment { get; set; }
        public string CustomerComment { get; set; }

        public string FutureMaintenance { get; set; }
        public int ServiceOrderId { get; set; }
        public List<ServiceOrderJobGroupModel> JobGroups { get; set; }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerZipcode { get; set; }
        public string CustomerTelephoneNumber { get; set; }

    }
  
    public class ServiceOrderJobGroupModel
    {
        public string Name { get; set; }

        public List<string> Jobs { get; set; }
    }

}
