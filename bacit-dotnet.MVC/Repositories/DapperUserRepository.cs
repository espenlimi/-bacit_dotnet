using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
using MySqlConnector;

namespace bacit_dotnet.MVC.Repositories
{
    /// <summary>
    /// Using packages Dapper and Dapper.Contrib
    /// </summary>
    public class DapperUserRepository : IUserRepository
    {
        private readonly ISqlConnector sqlConnector;

        public DapperUserRepository(ISqlConnector sqlConnector)
        {
            this.sqlConnector = sqlConnector;
        }
        public void Delete(string email)
        {
            using (var connection = sqlConnector.GetDbConnection() as MySqlConnection)
            {
                var users = connection.QueryFirstOrDefault<UserEntity>("Select id, name, email, phone from users where email like @param ", param: email); 
            }
        }

        public List<UserEntity> GetUsers()
        {
            using (var connection = sqlConnector.GetDbConnection() as MySqlConnection)
            {
                var users = connection.Query<UserEntity>("Select id, name, email, phone from users;"); //Regular Dapper
                return users.ToList();
            }
        }

        public void Save(UserEntity user)
        {
            using (var connection = sqlConnector.GetDbConnection() as MySqlConnection)
            {
                var users = connection.Insert(user); //Dapper.Contrib
            }
        }
    }
}
