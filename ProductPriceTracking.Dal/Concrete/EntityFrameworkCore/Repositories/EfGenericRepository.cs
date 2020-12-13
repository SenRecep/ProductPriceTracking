using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ProductPriceTracking.Core.Entities.Interfaces;
using ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Contexts;
using ProductPriceTracking.Dal.Interfaces;

namespace ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntityBase, new()
    {
        private readonly ProductPriceTrackingDbContext context;
        private readonly DbSet<TEntity> table;


        public EfGenericRepository(ProductPriceTrackingDbContext context)
        {
            this.context = context;
            table = context.Set<TEntity>();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await table.AsQueryable().ToListAsync();
        }
        public async Task<ICollection<TEntity>> GetAllNotDeletedAsync()
        {
            return await GetAllByFilterAsync(x => !x.IsDeleted);
        }
        public async Task<ICollection<TEntity>> GetAllByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await table.Where(filter).ToListAsync();
        }
        public async Task<ICollection<TEntity>> GetAllByFilterNotDeletedAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await table.Where(x => !x.IsDeleted).Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetByFilterNotDeletedAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await table.Where(x => !x.IsDeleted).FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await table.FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await GetByFilterAsync(x => x.Id == Id);
        }


        public async Task AddAsync(TEntity entity, bool save = true)
        {
            entity.CreateDate = DateTime.Now;
            await table.AddAsync(entity);
            await SaveChangesAsync(save);
        }

        public async Task HardRemoveAsync(TEntity entity, bool save = true)
        {
            table.Remove(entity);
            await SaveChangesAsync(save);
        }

        public async Task RemoveAsync(TEntity entity, bool save = true)
        {
            entity.IsDeleted = true;
            await UpdateAsync(entity, save);
        }

        public async Task UpdateAsync(TEntity entity, bool save = true)
        {
            entity.UpdateDate = DateTime.Now;
            table.Update(entity);
            await SaveChangesAsync(save);
        }


        public async Task SaveChangesAsync(bool save = true)
        {
            if (save)
                await context.SaveChangesAsync();
        }


    }
}
