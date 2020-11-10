using AutoMapper;
using Leilao.ApplicationService.Interfaces;
using Leilao.ApplicationService.ViewModels.Request.User;
using Leilao.ApplicationService.ViewModels.Response;
using Leilao.Domain.Commands.User;
using Leilao.Domain.Core.Bus;
using Leilao.Domain.Core.Notifications;
using Leilao.Domain.Interfaces.Repositories;
using Leilao.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leilao.ApplicationService.Services {

    public class UserApplicationService : IUserApplicationService {
        
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IMediatorHandler _bus;

        public UserApplicationService(
            IMapper mapper,
            IUserRepository userRepository,
            IMediatorHandler bus
        ) {
            _mapper = mapper;
            _userRepository = userRepository;
            _bus = bus;
        }

        public async Task<List<UserResponseViewModel>> GetAllUsers() {

            var result = await _userRepository.GetAll();

            var resultMapped = _mapper.Map<List<UserResponseViewModel>>(result);

            return resultMapped;

        }

        public async Task<UserResponseViewModel> GetUserById(Guid id) {

            if(id == null) {
                await _bus.RaiseEvent(new DomainNotification("GetById", "Id cannot be null."));
                return null;
            }

            var result = await _userRepository.GetById(id);

            var resultMapped = _mapper.Map<UserResponseViewModel>(result);

            return resultMapped;

        }

        public async Task<UserResponseViewModel> CreateUser(CreateUserRequestViewModel viewModel) {

            var command = _mapper.Map<CreateUserCommand>(viewModel);

            var result = await _bus.SendCommand<CreateUserCommand, User>(command);

            var resultMapped = _mapper.Map<UserResponseViewModel>(result);

            return resultMapped;
        }


    }
}
