using bacit_dotnet.MVC.Entities;
using MySqlConnector;

namespace bacit_dotnet.MVC.DataAccess
{
    public class SqlConnector : ISqlConnector
    {
        private readonly IConfiguration config;

        public SqlConnector(IConfiguration config)
        {
            this.config = config;
        }

        public IEnumerable<User> GetUsers()
        {
            using (var connection = new MySqlConnection(config.GetConnectionString("MariaDb")))
            {
                var reader = ReadData("Select id, name, email, phone from users;", connection);

                var users = new List<User>();
                while (reader.Read())
                {
                    var user = new User();
                    user.Id = reader.GetInt32("id");
                    user.Name = reader.GetString(1);
                    user.Email = reader.GetString(2);
                    user.Phone = reader.GetString(3);
                }
                connection.Close();
                return users;

            }
        }

        private MySqlDataReader ReadData(string query, MySqlConnection connection)
        {
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            return command.ExecuteReader();
        }
    }
}
