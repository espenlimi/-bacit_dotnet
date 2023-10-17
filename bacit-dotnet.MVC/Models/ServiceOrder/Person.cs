// Models/Person.cs
using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models
{
    public class Person
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Date is required.")]
        public string Dato { get; set; }
        
        [Required(ErrorMessage = "Order number is required.")]
        public string Ordrenummer { get; set; }
        
        [Required(ErrorMessage = "Name is required.")]
        public string Navn { get; set; }
        
        [Required(ErrorMessage = "Status on order is required.")]
        public string Status { get; set; }
    }
}