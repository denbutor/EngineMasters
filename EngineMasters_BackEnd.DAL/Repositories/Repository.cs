using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EngineMasters_BackEnd.DAL.Interfaces;

namespace EngineMasters_BackEnd.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            Context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}