using Leilao.Domain.Commands.Bid;

namespace Leilao.Domain.Validations.Bid {

    public class CreateBidCommandValidation : BidValidation<CreateBidCommand> {

        public CreateBidCommandValidation() {
            ValidateIdProduct();
            ValidateIdUser();
            ValidatePriceOffer();
        }

    }
}
