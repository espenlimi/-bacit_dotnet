﻿using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Entities;
using Microsoft.AspNetCore.Identity;

namespace bacit_dotnet.MVC.Repositories
{
    public class EFUserRepository : UserRepositoryBase, IUserRepository
    {
        private readonly DataContext dataContext;

        public EFUserRepository(DataContext dataContext, UserManager<IdentityUser> userManager) : base(userManager)
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

        public List<UserEntity> GetEspens()
        { 
            return dataContext.Users
                .Where(user=> user.Name.Contains("Espen") && 
                    user.Email.Contains("@"))
                .ToList();
        }

        public void Add(UserEntity user)
        {
            var existingUser = GetUserByEmail(user.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists found");
            }
            dataContext.Users.Add(user);
            dataContext.SaveChanges();
        }
        public void Update(UserEntity user, List<string> roles)
        {
            var existingUser = GetUserByEmail(user.Email);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            existingUser.Email = user.Email;
            existingUser.Name = user.Name;
            dataContext.SaveChanges();
            SetRoles(user.Email, roles);
        }
    }
}
