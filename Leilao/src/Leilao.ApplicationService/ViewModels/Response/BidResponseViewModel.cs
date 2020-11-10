using System;

namespace Leilao.ApplicationService.ViewModels.Response {
    public class BidResponseViewModel {

        public Guid Id { get; set; }
        public ProductResponseViewModel Product { get; set; }
        public UserResponseViewModel User { get; set; }
        public decimal PriceOffer { get; set; }
        public bool IsSupered { get; set; }

    }
}
