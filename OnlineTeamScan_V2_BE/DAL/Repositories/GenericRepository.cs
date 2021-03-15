using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        protected readonly OnlineTeamScanContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(OnlineTeamScanContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query.AsNoTracking().ToList();
        }       

        public TEntity Add(TEntity entity)
        {
            var newEntity = _dbSet.Add(entity);

            return newEntity.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var updatedEntity = _dbSet.Update(entity);

            return updatedEntity.Entity;
        }

        public void Delete(int id)
        {
            TEntity deletedEntity = _dbSet.Find(id);

            _dbSet.Remove(deletedEntity);
        }
    }
}
