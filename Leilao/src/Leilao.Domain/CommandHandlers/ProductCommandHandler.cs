using AutoMapper;
using Leilao.Domain.CommandHandlers.Base;
using Leilao.Domain.Commands.Product;
using Leilao.Domain.Core.Bus;
using Leilao.Domain.Interfaces.Repositories;
using Leilao.Domain.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leilao.Domain.CommandHandlers {

    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<CreateProductCommand, Product> {

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductCommandHandler(
            IMediatorHandler bus,
            IMapper mapper,
            IProductRepository productRepository
        ) : base(bus) {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken) {

            if(!request.IsValid()) {
                NotifyValidationErrors(request);
                return null;
            }

            var modelToInsert = _mapper.Map<Product>(request);

            var resultInsert = await _productRepository.Insert(modelToInsert);

            return resultInsert;
        }

    }
}
