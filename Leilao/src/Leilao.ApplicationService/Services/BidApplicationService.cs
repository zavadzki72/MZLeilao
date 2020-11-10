using AutoMapper;
using Leilao.ApplicationService.Interfaces;
using Leilao.ApplicationService.ViewModels.Request.Bid;
using Leilao.ApplicationService.ViewModels.Response;
using Leilao.Domain.Commands.Bid;
using Leilao.Domain.Core.Bus;
using Leilao.Domain.Interfaces.Repositories;
using Leilao.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leilao.ApplicationService.Services {

    public class BidApplicationService : IBidApplicationService {

        private readonly IMapper _mapper;
        private readonly IBidRepository _bidRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMediatorHandler _bus;

        public BidApplicationService(
            IMapper mapper,
            IBidRepository bidRepository,
            IProductRepository productRepository,
            IUserRepository userRepository,
            IMediatorHandler bus
        ) {
            _mapper = mapper;
            _bidRepository = bidRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _bus = bus;
        }

        public async Task<List<BidResponseViewModel>> GetAllBids() {

            List<BidResponseViewModel> response = new List<BidResponseViewModel>();

            var result = await _bidRepository.GetAll();

            foreach(var index in result) {
                var product = _mapper.Map<ProductResponseViewModel>(index.Product);
                var user = _mapper.Map<UserResponseViewModel>(index.User);

                var mappedResult = _mapper.Map<BidResponseViewModel>(index);
                mappedResult.Product = product;
                mappedResult.User = user;

                response.Add(mappedResult);
            }

            return response;
        }

        public Task<BidResponseViewModel> GetBidById(Guid id) {
            throw new NotImplementedException();
        }

        public Task<List<BidResponseViewModel>> GetBidsInProgress() {
            throw new NotImplementedException();
        }

        public Task<List<BidResponseViewModel>> GetFinishedBids() {
            throw new NotImplementedException();
        }


        public async Task<BidResponseViewModel> CreateBid(CreateBidRequestViewModel viewModel) {

            if(!(await CanOfferBid(viewModel)))
                return null;

            var command = _mapper.Map<CreateBidCommand>(viewModel);

            var result = await _bus.SendCommand<CreateBidCommand, Bid>(command);

            var productModel = await _productRepository.GetById(result.IdProduct);
            var userModel = await _userRepository.GetById(result.IdUser);

            var product = _mapper.Map<ProductResponseViewModel>(productModel);
            var user = _mapper.Map<UserResponseViewModel>(userModel);

            var resultMapped = _mapper.Map<BidResponseViewModel>(result);
            resultMapped.Product = product;
            resultMapped.User = user;

            return resultMapped;
        }

        public Task<BidResponseViewModel> FinishBid(Guid id) {
            throw new NotImplementedException();
        }

        private async Task<bool> CanOfferBid(CreateBidRequestViewModel viewModel) {

            var product = await _productRepository.GetById(viewModel.IdProduct);

            if(viewModel.PriceOffer < product.Price)
                return false;

            var bids = await _bidRepository.GetByProductId(viewModel.IdProduct);

            bool ret = true;

            bids.ForEach(x => {

                if(x.PriceOffer > viewModel.PriceOffer)
                    ret = false;
            });

            return ret;
        }
  
    }
}
