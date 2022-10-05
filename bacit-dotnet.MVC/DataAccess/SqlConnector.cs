using bacit_dotnet.MVC.Entities;
using MySqlConnector;
using System.Data;
using System.Data.Common;

namespace bacit_dotnet.MVC.DataAccess
{
    public class SqlConnector : ISqlConnector
    {
        private readonly IConfiguration config;

        public SqlConnector(IConfiguration config)
        {
            this.config = config;
        }

        public IEnumerable<UserEntity> GetUsers()
        {
            using var connection = new MySqlConnection(config.GetConnectionString("MariaDB"));
            connection.Open();
            var reader = ReadData("Select id, name, email, employeenumber, team, role from users;", connection);
            var users = new List<UserEntity>();
            while (reader.Read())
            {
                var user = new UserEntity();
                user.Id = reader.GetInt32("id");
                user.Name = reader.GetString(1);
                user.Email = reader.GetString(2);
                user.EmployeeNumber = reader.GetString(3);
                user.Team = reader.GetString(4);
                user.Role = reader.GetString(5);
                Console.WriteLine(reader.GetString(3));
                users.Add(user);
            }
            connection.Close();
            return users;
        }

        public IDbConnection GetDbConnection()
        {
            return new MySqlConnection(config.GetConnectionString("MariaDb"));
        }

        private MySqlDataReader ReadData(string query, MySqlConnection conn)
        {
            using var command = conn.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            return command.ExecuteReader();
        }
          
    }
}
