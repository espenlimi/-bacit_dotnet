using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
using MySqlConnector;

namespace bacit_dotnet.MVC.Repositories
{
    public class DapperSuggestionRepository : ISuggestionRepository
    {
        private readonly ISqlConnector sqlConnector;

        public DapperSuggestionRepository(ISqlConnector sqlConnector)
        {
            this.sqlConnector = sqlConnector;
        }

        public List<SuggestionEntity> getAll()
        {
            using(var connection = sqlConnector.GetDbConnection() as MySqlConnection) { 
               var suggestions = connection.Query<SuggestionEntity>("SELECT * FROM Suggestion;");
               return suggestions.ToList();
            }
        }
    }
}
