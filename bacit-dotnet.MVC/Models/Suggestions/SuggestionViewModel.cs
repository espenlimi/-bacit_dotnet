using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models.Suggestions
{
    public class SuggestionViewModel
    {
        [Required]
        [MinLength(7, ErrorMessage ="Skriv en ordentlig tittel!")]
        public string Title { get; set; }
        public string Name { get; set; }
        public int Team { get; set; }
        public string Description { get; set; }

        public DateTime TimeStamp { get; set; }
        public SuggestionViewModel()
        {
            this.TimeStamp = DateTime.Now;
        }
    }
}
