using System;

namespace Leilao.ApplicationService.ViewModels.Response {
    public class BidResponseViewModel {

        public Guid Id { get; set; }
        public ProductResponseViewModel Product { get; set; }
        public UserResponseViewModel User { get; set; }
        public decimal PriceOffer { get; set; }
        public int QtdBids { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsOver { get; set; }

    }
}
