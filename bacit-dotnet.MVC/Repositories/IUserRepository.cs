using bacit_dotnet.MVC.Entities;

namespace bacit_dotnet.MVC.Repositories
{
    public interface IUserRepository
    {
        void Update(UserEntity user, List<string> roles);
        void Add(UserEntity user);
        List<UserEntity> GetUsers();
        void Delete(string email);
        bool IsAdmin(string email);
    }
}