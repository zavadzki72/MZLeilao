using Leilao.ApplicationService.Interfaces;
using Leilao.ApplicationService.ViewModels.Request.Bid;
using Leilao.ApplicationService.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leilao.ApplicationService.Services {

    public class BidApplicationService : IBidApplicationService {

        public Task<BidResponseViewModel> CreateBid(CreateBidRequestViewModel viewModel) {
            throw new NotImplementedException();
        }

        public Task<BidResponseViewModel> FinishBid(Guid id) {
            throw new NotImplementedException();
        }

        public Task<List<BidResponseViewModel>> GetAllBids() {
            throw new NotImplementedException();
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
    }
}
