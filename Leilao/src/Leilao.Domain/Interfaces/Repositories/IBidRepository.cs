using Leilao.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leilao.Domain.Interfaces.Repositories {

    public interface IBidRepository : IBaseRepository<Bid> {

        Task<List<Bid>> GetByProductId(Guid idProduct);

    }
}
