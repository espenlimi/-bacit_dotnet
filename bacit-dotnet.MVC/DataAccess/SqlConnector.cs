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

            using var connection = new MySqlConnection(config.GetConnectionString("MariaDb"));
            connection.Open();

            var reader = ReadData("Select id, name, email, phone from users;", connection);

            var users = new List<User>();
            while (reader.Read())
            {
                var user = new User();
                user.Id = reader.GetInt32("id");
                user.Name = reader.GetString(1);
                user.Email = reader.GetString(2);
                user.Phone = reader.GetString(3);
                users.Add(user);
            }
            connection.Close();
            return users;
        }

        private MySqlDataReader ReadData(string query,MySqlConnection conn)
        {
            
            using var command = conn.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            return command.ExecuteReader();
        }

        private void SaveSuggestions(MySqlConnection conn)
       {
        string query = "insert into suggestions (Id, Title, Name, Team, Description) values (7, \"Tittel\", \"Navn\", 5, \"Dette er en beskrivelse av mitt problem\")";
        using var command = conn.CreateCommand();
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = query; 
        command.ExecuteNonQuery();
       } 

       public void SetSuggestions()
       {
        using var connection = new MySqlConnection(config.GetConnectionString("MariaDb"));
        connection.Open();
        SaveSuggestions(connection);
       }
    }
}
