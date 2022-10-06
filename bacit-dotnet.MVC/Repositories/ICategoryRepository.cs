using bacit_dotnet.MVC.Entities;
using bacit_dotnet.MVC.Repositories;
namespace bacit_dotnet.MVC.Repositories
{
  
   public interface ICategoryRepository
         {
             public List<CategoryEntity> getAll();
         }
    
}

