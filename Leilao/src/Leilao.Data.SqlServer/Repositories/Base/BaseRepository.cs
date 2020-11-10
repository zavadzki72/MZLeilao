using Leilao.Data.SqlServer.Context;
using Leilao.Domain.Interfaces.Repositories;
using Leilao.Domain.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leilao.Data.SqlServer.Repositories.Base {

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new() {

        protected readonly ApplicationDbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(ApplicationDbContext db) {
            DbContext = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAll() {
            
            try {
                return await DbSet.ToListAsync();
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public virtual async Task<TEntity> GetById(Guid id) {
            return await DbSet.FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity item) {
            DbSet.Add(item);
            await SaveChanges();
            return item;
        }

        public async Task<TEntity> Update(TEntity item) {

            try {
                TEntity result = await GetById(item.Id);

                if(result == null)
                    return null;

                DbContext.Entry(result).State = EntityState.Detached;

                var entry = DbContext.Entry(item);
                if(entry.State == EntityState.Detached)
                    DbContext.Attach(item);

                DbContext.Entry(item).State = EntityState.Modified;
                await SaveChanges();

                return item;
            } catch {
                return null;
            }
        }

        public virtual async Task Delete(Guid id) {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }
        
        public async Task<int> SaveChanges() {
            return await DbContext.SaveChangesAsync();
        }

        public void Dispose() {
            DbContext?.Dispose();
        }

    }
}
