using Leilao.ApplicationService.ViewModels.Request.Bid;
using Leilao.ApplicationService.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leilao.ApplicationService.Interfaces {
    public interface IBidApplicationService {

        Task<List<BidResponseViewModel>> GetAllBids();
        Task<List<BidResponseViewModel>> GetBidsInProgress();
        Task<List<BidResponseViewModel>> GetFinishedBids();
        Task<BidResponseViewModel> GetBidById(Guid id);
        Task<BidResponseViewModel> FinishBid(Guid id);
        Task<BidResponseViewModel> CreateBid(CreateBidRequestViewModel viewModel);

    }
}
