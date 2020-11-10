using Leilao.ApplicationService.ViewModels.Request.User;
using Leilao.ApplicationService.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leilao.ApplicationService.Interfaces {

    public interface IUserApplicationService {

        Task<List<UserResponseViewModel>> GetAllUsers();
        Task<UserResponseViewModel> GetUserById(Guid id);
        Task<UserResponseViewModel> CreateUser(CreateUserRequestViewModel viewModel);

    }
}
