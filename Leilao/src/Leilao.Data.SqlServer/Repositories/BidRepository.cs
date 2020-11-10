using Leilao.Data.SqlServer.Context;
using Leilao.Data.SqlServer.Repositories.Base;
using Leilao.Domain.Interfaces.Repositories;
using Leilao.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leilao.Data.SqlServer.Repositories {

    public class BidRepository : BaseRepository<Bid>, IBidRepository {

        public BidRepository(ApplicationDbContext db) : base(db) { }

        public override async Task<List<Bid>> GetAll() {
            return await DbSet.Include("User").Include("Product").ToListAsync();
        }

        public async Task<List<Bid>> GetByProductId(Guid idProduct) {
            return await DbSet.Include("User").Include("Product").Where(x => x.IdProduct == idProduct).ToListAsync();
        }
       
    }
}
