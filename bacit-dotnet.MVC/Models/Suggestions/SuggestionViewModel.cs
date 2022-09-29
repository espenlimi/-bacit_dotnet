using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models.Suggestions
{
    public class SuggestionViewModel
    {
        [Required]
        [MinLength(7, ErrorMessage ="Skriv en ordentlig tittel!")]
        public string Title { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string Description { get; set; }
        public string TimeStamp { get; set; }
    }
}
