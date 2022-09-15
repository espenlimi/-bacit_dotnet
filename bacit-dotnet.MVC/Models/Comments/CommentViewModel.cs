namespace bacit_dotnet.MVC.Models.Comments
{
    public class CommentViewModel
    {
        public int comment_id { get; set; }
        public int emp_id { get; set; }
        public DateTime DateTime { get; set; }
        public int suggestion_id { get; set; }
        public string description { get; set; }

    }
}
