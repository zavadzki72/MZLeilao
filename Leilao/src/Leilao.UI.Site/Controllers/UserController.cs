using Leilao.ApplicationService.Interfaces;
using Leilao.ApplicationService.ViewModels.Request.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leilao.UI.Site.Controllers {

    public class UserController : Controller {

        private readonly IUserApplicationService _userApplicationService;

        public UserController(IUserApplicationService userApplicationService) {
            _userApplicationService = userApplicationService;
        }

        [HttpGet]
        public IActionResult CreateUser() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequestViewModel viewModel) {

            await _userApplicationService.CreateUser(viewModel);

            return RedirectToAction("Index", "Home");
        }

    }
}
