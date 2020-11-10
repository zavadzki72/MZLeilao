using Leilao.Domain.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leilao.Domain.Interfaces.Repositories {

    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity {

        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<TEntity> Insert(TEntity item);
        Task<TEntity> Update(TEntity item);
        Task Delete(Guid id);
    }
}
