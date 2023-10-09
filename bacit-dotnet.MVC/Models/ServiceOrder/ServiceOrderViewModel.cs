namespace bacit_dotnet.MVC.Models.ServiceOrder
{
    public class ServiceOrderViewModel
    {
        public int ServiceOrderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerZipcode { get; set; }
        public string CustomerTelephoneNumber { get; set; }

    }

}
