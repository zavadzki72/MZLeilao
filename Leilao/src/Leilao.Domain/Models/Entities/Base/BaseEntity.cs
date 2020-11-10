using Leilao.Domain.Interfaces.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leilao.Domain.Models.Entities.Base {

    public abstract class BaseEntity : IBaseEntity {

        public BaseEntity() {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required()]
        [Column("dta_creation")]
        public DateTime CreationDate { get; set; }

        [Required()]
        [Column("dta_update")]
        public DateTime UpdateDate { get; set; }
    }
}
