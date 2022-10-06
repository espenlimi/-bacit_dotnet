using bacit_dotnet.MVC.Entities;

namespace bacit_dotnet.MVC.Repositories
{
    public interface ISuggestionRepository
    {
        List<SuggestionEntity> getAll();
    }
}
