using Leilao.Domain.Core.Command;
using System;
using Model = Leilao.Domain.Models.Entities;

namespace Leilao.Domain.Commands.Product {

    public abstract class ProductCommand : Command<Model.Product> {

        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
