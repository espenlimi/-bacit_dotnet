using System.Runtime.InteropServices.JavaScript;

namespace bacit_dotnet.MVC.Models.ServiceOrder;

public class NewServiceOrderViewModel
{
    public string Kunde { get; set; }
    
    public DateTime MottattDato { get; set; }
    
    public string Adresse { get; set; }
    
    public string Email { get; set; }
    
    public int Ordrenummer { get; set; }
    
    public int telefon { get; set; }
    
    public string Produkttype { get; set; }
    
    public int Årsmodell { get; set; }
    
    public string Garanti { get; set; }
    
    public string Serienummer { get; set; }
    
    public string Avtale { get; set; }
    
    public string Reparasjonsbeskrivelse { get; set; }
    
    public string MedgåtteDeler { get; set; }
    
}