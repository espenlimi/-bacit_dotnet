using System.ComponentModel.DataAnnotations.Schema;

namespace bacit_dotnet.MVC.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
    }
}
