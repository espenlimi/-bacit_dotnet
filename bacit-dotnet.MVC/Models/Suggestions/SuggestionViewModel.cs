using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models.Suggestions
{
    public class SuggestionViewModel
    {
        [Required]
        [MinLength(30, ErrorMessage = "Skriv en ordentlig tittel!")]
        public string Title { get; set; } = default!;

        public string ? Files { get; set; }

        [Required(ErrorMessage = "Beskrivelse trengs")]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; } = default!;

        [Required]
        public string TimeStamp { get; set; } = default!;

        [Required]
        public string Status { get; set; } = default!;

        public string ? Deadline { get; set; }

        //from Employee
        [Required]
        public string Name { get; set; } = default!;

    }
}
