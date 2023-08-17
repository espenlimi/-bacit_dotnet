using bacit_dotnet.MVC.Entities;
using Microsoft.AspNetCore.Identity;

namespace bacit_dotnet.MVC.Repositories
{
    public class InMemoryUserRepository : UserRepositoryBase, IUserRepository
    {
        private List<UserEntity> users;
        public InMemoryUserRepository(UserManager<IdentityUser> userManager) : base(userManager)
        {
            users = new List<UserEntity>();
        }
        public void Save(UserEntity user)
        {
            var existingUser = GetUserByEmail(user.Email);
            if (existingUser == null)
            {
                users.Add(user);
            }
            else
            {
                existingUser.Email = user.Email;
                existingUser.Name = user.Name;
            }
        }

        public void Add(UserEntity user)
        {
            var existingUser = GetUserByEmail(user.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }
            users.Add(user);
        }
        public void Update(UserEntity user, List<string> roles)
        {
            var existingUser = GetUserByEmail(user.Email);
            if (existingUser == null)
            {
                throw new Exception("User does not exist");
            }

            existingUser.Email = user.Email;
            existingUser.Name = user.Name;
            SetRoles(user.Email, roles);
        }

        public List<UserEntity> GetUsers()
        {
            return users;
        }

        public void Delete(string email)
        {
            UserEntity? foundUser = GetUserByEmail(email);
            if (foundUser != null)
            {
                users.Remove(foundUser);
            }
        }

        private UserEntity? GetUserByEmail(string email)
        {
            return users.FirstOrDefault(user =>
                             user.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
