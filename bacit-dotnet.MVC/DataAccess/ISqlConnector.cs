using bacit_dotnet.MVC.Entities;
using System.Data;

namespace bacit_dotnet.MVC.DataAccess
{
    public interface ISqlConnector
    {
        IEnumerable<UserEntity> GetUsers();
        IDbConnection GetDbConnection();

    }
}