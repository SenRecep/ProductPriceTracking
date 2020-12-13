using System.Collections.Generic;
using System.Threading.Tasks;

using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Core.Entities.Interfaces;
using ProductPriceTracking.Dal.Interfaces;

namespace ProductPriceTracking.Bll.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity>
       where TEntity : class, IEntityBase, new()
    {
        private readonly IGenericRepository<TEntity> repository;
        public GenericManager(IGenericRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await repository.GetAllNotDeletedAsync();
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await repository.GetByIdAsync(Id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await repository.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await repository.UpdateAsync(entity);
        }
        public async Task RemoveAsync(TEntity entity)
        {
            await repository.RemoveAsync(entity);
        }
    }
}
