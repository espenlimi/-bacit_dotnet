using Org.BouncyCastle.Bcpg;
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
        //For mekaniske delen av sjekklisten
        public string? mekanisk1 { get; set; }
        public string? mekanisk2 { get; set; }
        public string? mekanisk3 { get; set; }
        public string? mekanisk4 { get; set; }
        public string? mekanisk5 { get; set; }
        public string? mekanisk6 { get; set; }
        public string? mekanisk7 { get; set; }
        public string? mekanisk8 { get; set; }

        //For elektrodelen av sjekklisten
        public string? elektro1 { get; set; }
        public string? elektro2 { get; set; }
        public string? elektro3 { get; set; }

        //For hydraulikkdelen av sjekklisten
        public string? hydraulikk1 { get; set; }
        public string? hydraulikk2 { get; set; }
        public string? hydraulikk3 { get; set; }
        public string? hydraulikk4 { get; set; }
        public string? hydraulikk5 { get; set; }
        public string? hydraulikk6 { get; set; }
        public string? hydraulikk7 { get; set; }
        public string? hydraulikk8 { get; set; }

        //For Trykksettinger av sjekklisten
        public string? XXBar1 { get; set; }

        //For Funksjonstestdelen av sjekklisten
        public string? funksjonstest1 { get; set; }
        public string? funksjonstest2 { get; set; }
        public string? funksjonstest3 { get; set; }

    }

    public class ServiceOrderJobGroupModel
    {
        public string Name { get; set; }

        public List<string> Jobs { get; set; }
    }
}
