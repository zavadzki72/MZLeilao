using Leilao.Domain.Models.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leilao.Domain.Models.Entities {

    public class Bid : BaseEntity {

        public Bid() { }

        public Bid(Guid idProduct, Guid idUser, decimal priceOffer, bool isSupered = false) {
            IdProduct = idProduct;
            IdUser = idUser;
            PriceOffer = priceOffer;
            IsSupered = isSupered;
        }

        [Required()]
        [Column("price_offer")]
        public decimal PriceOffer { get; set; }

        [Required()]
        [Column("is_supered")]
        public bool IsSupered { get; set; }

        /* EF Relations */
        [ForeignKey("Product"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IdProduct { get; set; }

        public Product Product { get; set; }

        [ForeignKey("User"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IdUser { get; set; }

        public User User { get; set; }

    }
}
