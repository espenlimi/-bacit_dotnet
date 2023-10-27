using Dapper;
//using Microsoft.Extensions.Configuration;
//using MySql.Data.MySqlClient;
using MySqlConnector;
//using System.Collections.Generic;
using System.Data;
//using System.Linq;
using bacit_dotnet.MVC.Models.CheckList;


namespace bacit_dotnet.MVC.Repositories
{
    public class CheckListRepository
    {
        private readonly IConfiguration _config;

        public ChecklistRepository(IConfiguration config)
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

        public IEnumerable<CheckListViewModel> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<CheckListViewModel>("SELECT * FROM Checkpoints");
            }
        }
        
        /*public IEnumerable<ServiceFormViewModel> GetSomeOrderInfo()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<ServiceFormViewModel>("SELECT Customer, DateReceived, OrderNumber FROM ServiceFormEntry");
            }
        }*/

        public void Insert(CheckListViewModel CheckListViewModel)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Checkpoints () VALUES ()", CheckListViewModel);
            }
        }
    }
}