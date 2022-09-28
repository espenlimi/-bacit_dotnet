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
            var user = GetUserByEmail(email);
            if (user == null)
                return;
            using (var connection = sqlConnector.GetDbConnection() as MySqlConnection)
            {
                connection.Delete<UserEntity>(user);
            }
        }

        private UserEntity GetUserByEmail(string email)
        {
            using (var connection = sqlConnector.GetDbConnection() as MySqlConnection)
            {
                return connection.QueryFirstOrDefault<UserEntity>("Select id, Name, Email, Password,EmployeeNumber,Team, Role from users where email like @emailParameter; ", new { emailParameter = email });
            }
        }

        public List<UserEntity> GetUsers()
        {
            using (var connection = sqlConnector.GetDbConnection() as MySqlConnection)
            {
                var users = connection.Query<UserEntity>("Select id, Name, Email, Password,EmployeeNumber,Team, Role from users;"); //Regular Dapper
                return users.ToList();
            }
        }

        public void Save(UserEntity user)
        {
            var existingUser = GetUserByEmail(user.Email);
            using (var connection = sqlConnector.GetDbConnection() as MySqlConnection)
            {
                if (existingUser != null)
                {
                    user.Id = existingUser.Id; // set this so the update-magic knows what record to update. 
                    connection.Update<UserEntity>(user); //Dapper.Contrib
                }
                else
                {
                    connection.Insert<UserEntity>(user); //Dapper.Contrib
                }
            }
        }
    }
}
