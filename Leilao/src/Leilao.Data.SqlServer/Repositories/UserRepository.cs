using Leilao.Data.SqlServer.Context;
using Leilao.Data.SqlServer.Repositories.Base;
using Leilao.Domain.Interfaces.Repositories;
using Leilao.Domain.Models.Entities;

namespace Leilao.Data.SqlServer.Repositories {

    public class UserRepository : BaseRepository<User>, IUserRepository {

        public UserRepository(ApplicationDbContext db) : base(db) { }
    
    }
}
