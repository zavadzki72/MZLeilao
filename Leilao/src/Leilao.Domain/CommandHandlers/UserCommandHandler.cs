using AutoMapper;
using Leilao.Domain.CommandHandlers.Base;
using Leilao.Domain.Commands.User;
using Leilao.Domain.Core.Bus;
using Leilao.Domain.Interfaces.Repositories;
using Leilao.Domain.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leilao.Domain.CommandHandlers {

    public class UserCommandHandler : CommandHandler,
        IRequestHandler<CreateUserCommand, User> {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(
            IMediatorHandler bus,
            IMapper mapper,
            IUserRepository userRepository
        ) : base(bus) {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken) {

            if(!request.IsValid()) {
                NotifyValidationErrors(request);
                return null;
            }

            var modelToInsert = _mapper.Map<User>(request);

            var resultInsert = await _userRepository.Insert(modelToInsert);

            return resultInsert;
        }
    }
}
