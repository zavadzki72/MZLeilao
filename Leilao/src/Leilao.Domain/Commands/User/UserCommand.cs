using Leilao.Domain.Core.Command;
using System;
using Model = Leilao.Domain.Models.Entities;

namespace Leilao.Domain.Commands.User {

    public abstract class UserCommand : Command<Model.User> {

        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
