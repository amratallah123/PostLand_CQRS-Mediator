using Microsoft.EntityFrameworkCore;
using PostLand.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Persistence
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly PostDbContext _DbContext;

        public BaseRepository(PostDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public async Task<T> AddAsync(T Entity)
        {
            await _DbContext.Set<T>().AddAsync(Entity);
            await _DbContext.SaveChangesAsync();
            return Entity;
        }

        public async Task DeleteAsync(T Entity)
        {
            _DbContext.Set<T>().Remove(Entity);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _DbContext.Set<T>().FindAsync(id) ?? throw new InvalidDataException("Not found");
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _DbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T Entity)
        {
            _DbContext.Entry(Entity).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();
        }
    }
}
