using bacit_dotnet.MVC.Entities;

namespace bacit_dotnet.MVC.Repositories
{
    public interface IEmployeeRepository
    {
        void Save(EmployeeEntity emp);
        List<EmployeeEntity> GetAll();
        void Delete (EmployeeEntity emp);
    }
}
