using bacit_dotnet.MVC.Entities;
using MySqlConnector;
using bacit_dotnet.MVC.Models.Suggestions;

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

        private MySqlDataReader ReadData(string query, MySqlConnection conn)
        {

            using var command = conn.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            var result = command.ExecuteReader();
            Console.WriteLine(result);
            return result;
        }
        private MySqlDataReader ReadSpeData(string query, MySqlConnection conn, int id)
        {

            using var command = conn.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            command.Parameters.AddWithValue("@id", id);
            var result = command.ExecuteReader();
            Console.WriteLine(result);
            return result;
        }
        private void SaveSuggestions(MySqlConnection conn)
        {
            string query = "insert into suggestions (Title, Name, Team, Description) values (\"Tittel\", \"Navn\", 5, \"Dette er en beskrivelse av mitt problem\")";
            using var command = conn.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            command.ExecuteNonQuery();
        }

        public void SetSuggestionsParam(SuggestionViewModel model)
        {
            using var connection = new MySqlConnection(config.GetConnectionString("MariaDb"));
            connection.Open();
            var query = "insert into suggestions (Title, UserId, TeamId, Description, TimeAdded) values (@Title, @UserId, @TeamId, @Description, @TimeStamp)";
            InsertSuggestions(query, connection, model);
        }

        private void InsertSuggestions(string query, MySqlConnection conn, SuggestionViewModel model)
        {
            DateTime date1 = DateTime.Now; 
            using var command = conn.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            command.Parameters.AddWithValue("@Title", model.Title); 
            command.Parameters.AddWithValue("@UserId", model.Name);
            command.Parameters.AddWithValue("@TeamId", model.Team);
            command.Parameters.AddWithValue("@Description", model.Description);
            command.Parameters.AddWithValue("@TimeStamp", date1);
            command.ExecuteNonQuery();
        }
       
        public  IEnumerable<Suggestion> FetchSug() {
            using var connection = new MySqlConnection(config.GetConnectionString("MariaDb"));
            connection.Open();

            var Suggestions = new List<Suggestion>();
            var reader = ReadData("select sugId, Title, UserId, TeamId, Description, TimeStamp, Status from suggestions", connection);
            while (reader.Read())
            {
                var user = new Suggestion();
                user.sugId = reader.GetInt32("sugId");
                user.Title = reader.GetString("Title");
                user.Name = reader.GetString("UserId");
                user.Team = reader.GetInt32("TeamId");
                user.Description = reader.GetString("Description");
                user.TimeStamp = reader.GetDateTime("TimeStamp");
                user.Status = reader.GetString("Status");
                Suggestions.Add(user);
            }
            connection.Close();
            return Suggestions;
        }

         public  IEnumerable<Suggestion> FetSpeSug(int id) {
            using var connection = new MySqlConnection(config.GetConnectionString("MariaDb"));
            connection.Open();

            var Suggestions = new List<Suggestion>();
            var reader = ReadSpeData("select sugId, Title, UserId, TeamId, Description from suggestions where sugId = @id", connection, id);
            while (reader.Read())
            {
                var user = new Suggestion();
                user.sugId = reader.GetInt32("sugId");
                user.Title = reader.GetString("Title");
                user.Name = reader.GetString("UserId");
                user.Team = reader.GetInt32("TeamId");
                user.Description = reader.GetString("Description");
                Suggestions.Add(user);
            }
            connection.Close();
            return Suggestions;
        }

        public void UpdateValueSetSug(SuggestionViewModel model, int id)
        {
            using var connection = new MySqlConnection(config.GetConnectionString("MariaDb"));
            connection.Open();
            
            var query = "update suggestions set title=@Title,userid=@Name,teamId = @Team,description=@Description where sugId =  @id;";
            UpdateSuggestions(query, connection, model, id);
            
        }

        private void UpdateSuggestions(String query, MySqlConnection conn, SuggestionViewModel user, int id)
        {
            Console.WriteLine(id);
            
            using var command = conn.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            command.Parameters.AddWithValue("@Title", user.Title); 
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Team", user.Team);
            command.Parameters.AddWithValue("@Description", user.Description);
            command.Parameters.AddWithValue("@id", id);
          
            command.ExecuteNonQuery();
        }
    }
}
