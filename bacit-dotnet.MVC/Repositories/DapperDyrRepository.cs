using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;

namespace bacit_dotnet.MVC.Repositories
{
    public class DapperDyrRepository : IDyrRepository
    {
        private readonly ISqlConnector _sqlConnector;

        public DapperDyrRepository(ISqlConnector sqlConnector)
        {
            _sqlConnector = sqlConnector;
        }
        public Dyr Get(int id)
        {
            using (var connection = _sqlConnector.GetDbConnection() )
            {
                return connection.QueryFirstOrDefault<Dyr>("Select id, Name from dyr where id like @idParam; ", new { idParam = id });
            }
        }

        public List<Dyr> GetAll()
        {
            using (var connection = _sqlConnector.GetDbConnection() )
            {
            //    connection.Open();
                return connection.Query<Dyr>("Select id, Name from dyr; ").ToList();
            }
        }

        public void Upsert(Dyr dyr)
        {
            var existing = Get(dyr.Id);
            using (var connection = _sqlConnector.GetDbConnection())
            {
                if (existing == null)
                {
                    dyr.Id = 0;
                    connection.Insert<Dyr>(dyr);
                    return;
                }
                existing.Name = dyr.Name;
                connection.Update<Dyr>(existing); //Dapper.Contrib
            }
        }
    }
}
