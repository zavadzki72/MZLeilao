using System;

namespace Leilao.ApplicationService.ViewModels.Request.Bid {

    public class CreateBidRequestViewModel {

        public Guid IdProduct { get; set; }
        public Guid IdUser { get; set; }
        public decimal PriceOffer { get; set; }
        public int QtdBids { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
