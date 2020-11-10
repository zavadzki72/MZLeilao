using AutoMapper;
using Leilao.Domain.CommandHandlers.Base;
using Leilao.Domain.Commands.Bid;
using Leilao.Domain.Core.Bus;
using Leilao.Domain.Interfaces.Repositories;
using Leilao.Domain.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leilao.Domain.CommandHandlers {

    public class BidCommandHandler : CommandHandler,
        IRequestHandler<CreateBidCommand, Bid> {

        private readonly IMapper _mapper;
        private readonly IBidRepository _bidRepository;

        public BidCommandHandler(
            IMediatorHandler bus,
            IMapper mapper,
            IBidRepository bidRepository
        ) : base(bus) {
            _mapper = mapper;
            _bidRepository = bidRepository;
        }

        public async Task<Bid> Handle(CreateBidCommand request, CancellationToken cancellationToken) {

            if(!request.IsValid()) {
                NotifyValidationErrors(request);
                return null;
            }

            var modelToInsert = _mapper.Map<Bid>(request);

            var resultInsert = await _bidRepository.Insert(modelToInsert);

            return resultInsert;
        }

    }
}
