using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Entities;

namespace bacit_dotnet.MVC.Repositories
{
    public class EfDyrRepository : IDyrRepository
    {
        private readonly DataContext _dataContext;

        public EfDyrRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        public Dyr Get(int id)
        {
            return _dataContext.Dyr.FirstOrDefault(x => x.Id == id);
        }

        public List<Dyr> GetAll()
        {
            return _dataContext.Dyr.ToList();
        }

        public void Upsert(Dyr dyr)
        {
            var existing = Get(dyr.Id);
            if(existing != null)
            {
                existing.Name = dyr.Name;
                _dataContext.SaveChanges();
                return;
            }
            dyr.Id = 0;
            _dataContext.Add(dyr);
            _dataContext.SaveChanges();
        }
    }
}
