using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Identity;
using MySqlConnector;

namespace bacit_dotnet.MVC.Repositories
{
    /// <summary>
    /// Using packages Dapper and Dapper.Contrib
    /// </summary>
    public class DapperUserRepository : UserRepositoryBase, IUserRepository
    {
        private readonly ISqlConnector sqlConnector;


        public DapperUserRepository(ISqlConnector sqlConnector, UserManager<IdentityUser> userManager) : base(userManager)
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
                return connection.QueryFirstOrDefault<UserEntity>("Select id, Name, Email from users where email like @emailParameter; ", new { emailParameter = email });
            }
        }

        public List<UserEntity> GetUsers()
        {
            using (var connection = sqlConnector.GetDbConnection() as MySqlConnection)
            {
                var users = connection.Query<UserEntity>("Select id, Name, Email from users;"); //Regular Dapper
                return users.ToList();
            }
        }

        public void Update(UserEntity user, List<string> roles)
        {
            var existingUser = GetUserByEmail(user.Email);
            using (var connection = sqlConnector.GetDbConnection() as MySqlConnection)
            {
                if (existingUser == null)
                {
                    throw new Exception("User not found");
                }
                user.Id = existingUser.Id; // set this so the update-magic knows what record to update. 
                connection.Update<UserEntity>(user); //Dapper.Contrib
            }
            SetRoles(user.Email, roles);
        }

        public void Add(UserEntity user)
        {
            var existingUser = GetUserByEmail(user.Email);
            using (var connection = sqlConnector.GetDbConnection() as MySqlConnection)
            {
                if (existingUser != null)
                {
                    throw new Exception("User already exits");
                }
                else
                {
                    connection.Insert<UserEntity>(user); //Dapper.Contrib
                }
            }
        }
    }
}
