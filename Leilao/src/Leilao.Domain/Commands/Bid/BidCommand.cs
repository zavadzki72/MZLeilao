using Leilao.Domain.Core.Command;
using Model = Leilao.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leilao.Domain.Commands.Bid {

    public abstract class BidCommand : Command<Model.Bid> {

        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public decimal PriceOffer { get; set; }
        public bool IsSupered { get; set; }


    }
}
