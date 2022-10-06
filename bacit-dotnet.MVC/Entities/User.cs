namespace bacit_dotnet.MVC.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class Suggestion
    {
       public string Title { get; set; }
        public string Name { get; set; }
        public int Team { get; set; }
        public string Description { get; set; }
    }


}
