using System;

namespace Leilao.ApplicationService.ViewModels.Request.Bid {

    public class CreateBidRequestViewModel {

        public Guid IdProduct { get; set; }
        public Guid IdUser { get; set; }
        public decimal PriceOffer { get; set; }

    }
}
