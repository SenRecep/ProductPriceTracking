using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ProductPriceTracking.Core.Entities.Interfaces;

namespace ProductPriceTracking.Dal.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntityBase, new()
    {
        Task<ICollection<TEntity>> GetAllAsync();
        Task<ICollection<TEntity>> GetAllNotDeletedAsync();
        Task<ICollection<TEntity>> GetAllByFilterAsync(Expression<Func<TEntity, bool>> filter);
        Task<ICollection<TEntity>> GetAllByFilterNotDeletedAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetByIdAsync(int Id);
        Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetByFilterNotDeletedAsync(Expression<Func<TEntity, bool>> filter);
        Task UpdateAsync(TEntity entity, bool save = true);
        Task RemoveAsync(TEntity entity, bool save = true);
        Task HardRemoveAsync(TEntity entity, bool save = true);
        Task AddAsync(TEntity entity, bool save = true);

        Task SaveChangesAsync(bool save = true);
    }
}
