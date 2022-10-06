using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
using MySqlConnector;

namespace bacit_dotnet.MVC.Repositories
{
    public class DapperCategoryRepository : ICategoryRepository
    {
        private readonly ISqlConnector sqlConnector;

        public DapperCategoryRepository(ISqlConnector sqlConnector)
        {
            this.sqlConnector = sqlConnector;
        }

        public List<CategoryEntity> getAll()
        {
            using (var connection = sqlConnector.GetDbConnection() as MySqlConnection)
            {
                var category = connection.Query<CategoryEntity>("SELECT * FROM Category");
                return category.ToList();
            }
        }
        
    }
}

