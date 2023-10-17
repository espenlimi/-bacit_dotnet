using Dapper;
using Microsoft.Extensions.Configuration;
//using MySql.Data.MySqlClient;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DapperMariaDBDemo.Models
{
    public class PersonRepository
    {
        private readonly IConfiguration _config;

        public PersonRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public IEnumerable<Person> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Person>("SELECT * FROM People");
            }
        }

        public void Insert(Person person)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO People (Dato, Ordrenummer, Navn, Status) VALUES (@Dato, @Ordrenummer, @Navn, @Status)", person);
            }
        }
    }
}