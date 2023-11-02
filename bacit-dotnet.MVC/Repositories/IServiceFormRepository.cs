using bacit_dotnet.MVC.Models.ServiceForm;

namespace bacit_dotnet.MVC.Repositories;

    public interface IServiceFormRepository
    {
        public IEnumerable<ServiceFormViewModel> GetAll();

        public IEnumerable<ServiceFormViewModel> GetSomeOrderInfo();
        
        
    }