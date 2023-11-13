using bacit_dotnet.MVC.Entities;

namespace bacit_dotnet.MVC.Repositories
{
    public interface IDyrRepository
    {
        void Upsert(Dyr dyr);
        Dyr Get(int id);
        List<Dyr> GetAll();
    }
}
