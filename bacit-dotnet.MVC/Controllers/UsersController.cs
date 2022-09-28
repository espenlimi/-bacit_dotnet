using bacit_dotnet.MVC.Entities;
using bacit_dotnet.MVC.Models.Users;
using bacit_dotnet.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers
{
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
                    model.EmployeeNumber = currentUser.EmployeeNumber;
                    model.Email = currentUser.Email;
                    model.Name = currentUser.Name;
                    model.Role = currentUser.Role;
                    model.Password = currentUser.Password;
                    model.Team = currentUser.Team;
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
                EmployeeNumber = model.EmployeeNumber,
                Password = model.Password,
                Role = model.Role,
                Team = model.Team,
            };
            userRepository.Save(newUser);
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
