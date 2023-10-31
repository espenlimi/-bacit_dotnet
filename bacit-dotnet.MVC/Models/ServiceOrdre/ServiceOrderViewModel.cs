using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models.ServiceOrdre
{
    public class ServiceOrderViewModel
    {
        //Serviceform
        [Key]
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; } 
        public string PreferredTimePeriod { get; set; } 
        public string Comment { get; set; }
    }

    public class WorkDocumentViewModel
    {
        public string Order { get; set; }
        public string Week { get; set; }
        public string Inquiry { get; set; }
        public bool CaseCompleted { get; set; }
        public string CustomerInfo { get; set; }
        public DateTime? PlannedDelivery { get; set; }
        public DateTime? ProductReceivedDate { get; set; }
        public DateTime? AgreedCompletionDate { get; set; }
        public DateTime? ServiceCompletedDate { get; set; }
        public string ServiceHours { get; set; }
        public bool HasOrderNumber { get; set; }
        public bool HasServiceForm { get; set; }
    }


    public class ChecklistViewModel
    {
        public string? Kategorier { get; set; }
        public string? Sjekkpunkter { get; set; }
        public bool OK { get; set; }
        public bool BørSkiftes { get; set; }
        public bool Defekt { get; set; }
    }

    public class ServiceOrderJobGroupModel
    {
        public string Name { get; set; }

        public List<string> Jobs { get; set; }
    }
}
