using Leilao.Domain.Models.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leilao.Domain.Models.Entities {

    public class Product : BaseEntity {

        public Product() { }

        public Product(string name, decimal price) {
            Name = name;
            Price = price;
        }

        [Required()]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required()]
        [Column("price")]
        public decimal Price { get; set; }

        /* EF Relations */
        public virtual List<Bid> Bids { get; set; }
    }
}
