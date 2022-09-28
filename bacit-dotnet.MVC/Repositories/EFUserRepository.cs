using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Entities;

namespace bacit_dotnet.MVC.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private readonly DataContext dataContext;

        public EFUserRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void Delete(string email)
        {
            UserEntity? user = GetUserByEmail(email);
            if (user == null)
                return;
            dataContext.Users.Remove(user);
            dataContext.SaveChanges();
        }

        private UserEntity? GetUserByEmail(string email)
        {
            return dataContext.Users.FirstOrDefault(x => x.Email == email);
        }

        public List<UserEntity> GetUsers()
        {
            return dataContext.Users.ToList();
        }

        public void Save(UserEntity user)
        {
            var existingUser = GetUserByEmail(user.Email);
            if (existingUser == null)
            {
                dataContext.Users.Add(user);
            }
            else
            {
                existingUser.Email = user.Email;
                existingUser.EmployeeNumber = user.EmployeeNumber;
                existingUser.Name = user.Name;
                existingUser.Role = user.Role;
                existingUser.Password = user.Password;
                existingUser.Team = user.Team;
            }
            dataContext.SaveChanges();
        }
    }
}
