namespace bacit_dotnet.MVC.Repositories
{
	public interface ISuggestionRepository
	{
		public void Save(SuggestionEntity suggestion);
		List<SuggestionEntity> GetSuggestions();
	}
}