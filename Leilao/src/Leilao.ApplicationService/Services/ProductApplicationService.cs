using AutoMapper;
using Leilao.ApplicationService.Interfaces;
using Leilao.ApplicationService.ViewModels.Request.Product;
using Leilao.ApplicationService.ViewModels.Response;
using Leilao.Domain.Commands.Product;
using Leilao.Domain.Core.Bus;
using Leilao.Domain.Core.Notifications;
using Leilao.Domain.Interfaces.Repositories;
using Leilao.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leilao.ApplicationService.Services {

    public class ProductApplicationService : IProductApplicationService {

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler _bus;

        public ProductApplicationService(
            IMapper mapper,
            IProductRepository productRepository,
            IMediatorHandler bus
        ) {
            _mapper = mapper;
            _productRepository = productRepository;
            _bus = bus;
        }

        public async Task<List<ProductResponseViewModel>> GetAllProducts() {
            
            var result = await _productRepository.GetAll();

            var resultMapped = _mapper.Map<List<ProductResponseViewModel>>(result);

            return resultMapped;

        }

        public async Task<ProductResponseViewModel> GetProductById(Guid id) {

            if(id == null) {
                await _bus.RaiseEvent(new DomainNotification("GetById", "Id cannot be null."));
                return null;
            }

            var result = await _productRepository.GetById(id);

            var resultMapped = _mapper.Map<ProductResponseViewModel>(result);

            return resultMapped;

        }

        public async Task<ProductResponseViewModel> CreateProduct(CreatePrductRequestViewModel viewModel) {

            var command = _mapper.Map<CreateProductCommand>(viewModel);

            var result = await _bus.SendCommand<CreateProductCommand, Product>(command);

            var resultMapped = _mapper.Map<ProductResponseViewModel>(result);

            return resultMapped;

        }


    }
}
