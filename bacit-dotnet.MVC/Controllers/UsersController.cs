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
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Save(UserViewModel model) {

            UserEntity newUser = new UserEntity { 
                Name = model.Name,
                Email = model.Email,
                EmployeeNumber = model.EmployeeNumber,
                Password = model.Password,
                Role = model.Role,
                Team = model.Team
            };
            userRepository.Save(newUser);
            return View("Index");
        }
    }
}
