using bacit_dotnet.MVC.Entities;
using bacit_dotnet.MVC.Models.Users;
using bacit_dotnet.MVC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers
{
    //[Authorize]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Index(string? email)
        {
            var model = new UserViewModel();
            model.Users = userRepository.GetUsers();
            if (email != null)
            {
                var currentUser = model.Users.FirstOrDefault(x => x.Email == email);
                if (currentUser != null)
                {

                    model.Email = currentUser.Email;
                    model.Name = currentUser.Name;
                    model.IsAdmin = userRepository.IsAdmin(currentUser.Email);
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Save(UserViewModel model)
        {

            UserEntity newUser = new UserEntity
            {
                Name = model.Name,
                Email = model.Email,
            };
            var roles = new List<string>();
            if (model.IsAdmin)
                roles.Add("Administrator");

            if (userRepository.GetUsers().FirstOrDefault(x => x.Email.Equals(newUser.Email, StringComparison.InvariantCultureIgnoreCase)) != null)
                userRepository.Update(newUser, roles);
            else
                userRepository.Add(newUser);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(string email)
        {
            userRepository.Delete(email);
            return RedirectToAction("Index");
        }
    }
}
