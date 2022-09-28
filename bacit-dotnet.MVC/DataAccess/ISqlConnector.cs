using bacit_dotnet.MVC.Entities;

namespace bacit_dotnet.MVC.DataAccess
{
    public interface ISqlConnector
    {
        IEnumerable<User> GetUsers();
        void SetSuggestions();
    }
}