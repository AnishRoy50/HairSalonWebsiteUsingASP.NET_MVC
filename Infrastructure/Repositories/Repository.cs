using System.Linq.Expressions;
using HairSalon.Core.Interfaces;
using HairSalon.Data;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Infrastructure.Repositories
{
    /// <summary>
    /// Generic repository implementation for data access
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly HairDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(HairDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual async Task<bool> ExistsAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            return entity != null;
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
