using Dapper;
using Dapper.Contrib.Extensions;
using ProductPriceTracking.Core.Entities.Interfaces;
using ProductPriceTracking.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductPriceTracking.Dal.Concrete.Dapper.Repositories
{
    public class DpGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntityBase, new()
    {
        private readonly IDbConnection dbConnection;

        public DpGenericRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task AddAsync(TEntity entity, bool save = true)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            var list = await dbConnection.GetAllAsync<TEntity>();
            return list.ToList();
        }

        public async Task<ICollection<TEntity>> GetAllByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            return null;
        }

        public async Task<ICollection<TEntity>> GetAllByFilterNotDeletedAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TEntity>> GetAllNotDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetByFilterNotDeletedAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task HardRemoveAsync(TEntity entity, bool save = true)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(TEntity entity, bool save = true)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync(bool save = true)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TEntity entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}
