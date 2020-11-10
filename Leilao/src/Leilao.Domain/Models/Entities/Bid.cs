using Leilao.Domain.Models.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leilao.Domain.Models.Entities {

    public class Bid : BaseEntity {

        public Bid() { }

        public Bid(Guid idProduct, Guid idUser, decimal priceOffer, int qtdBids, DateTime start, DateTime end, bool isOver = false) {
            IdProduct = idProduct;
            IdUser = idUser;
            PriceOffer = priceOffer;
            QtdBids = qtdBids;
            Start = start;
            End = end;
            IsOver = isOver;
        }

        [Required()]
        [Column("price_offer")]
        public decimal PriceOffer { get; set; }

        [Required()]
        [Column("qtde_bids")]
        public int QtdBids { get; set; }

        [Required()]
        [Column("dta_start")]
        public DateTime Start { get; set; }

        [Required()]
        [Column("dta_end")]
        public DateTime End { get; set; }

        [Required()]
        [Column("is_over")]
        public bool IsOver { get; set; }

        /* EF Relations */
        [ForeignKey("Product"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IdProduct { get; set; }

        public Product Product { get; set; }

        [ForeignKey("User"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IdUser { get; set; }

        public User User { get; set; }

    }
}
