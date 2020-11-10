using Leilao.Domain.Validations.Bid;
using System;

namespace Leilao.Domain.Commands.Bid {

    public class CreateBidCommand : BidCommand {

        public CreateBidCommand(Guid idProduct, Guid idUser, decimal priceOffer, int qtdBids, DateTime startTime, DateTime endTime) {
            ProductId = idProduct;
            UserId = idUser;
            PriceOffer = priceOffer;
            QtdBids = qtdBids;
            Start = startTime;
            End = endTime;
        }

        public override bool IsValid() {
            ValidationResult = new CreateBidCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
