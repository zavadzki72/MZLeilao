using Leilao.Domain.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leilao.Domain.Models.Entities {

    public class User : BaseEntity {

        public User() { }

        public User(string name, DateTime birthDate) {
            Name = name;
            BirthDate = birthDate;
        }

        [Required()]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required()]
        [Column("dta_birth")]
        public DateTime BirthDate { get; set; }

        /* EF Relations */
        public virtual List<Bid> Bids { get; set; }
    }
}
