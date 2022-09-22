namespace bacit_dotnet.MVC.Repositories 
{
	public class InMemorySuggestionRepository : ISuggestionRepository
	{
		private List<SuggestionEntity> suggestions;
		public InMemorySuggestionRepository()
		{
			suggestions = new List<SuggestionEntity>();
		}
		public void Save(SuggestionEntity suggestion)
		{
			suggestions.Add(suggestion);
		}
		public List<SuggestionEntity> GetSuggestions()
		{
			return suggestions;
		}
}

	public class SuggestionEntity
	{
		public string Title { get; set; }
		public string Files { get; set; }
		public string Description { get; set; }
		public string TimeStamp { get; set; }
		public string Status { get; set; }
		public string Deadline { get; set; }
		public string Name { get; set; } 
	}