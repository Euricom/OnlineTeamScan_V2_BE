using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        public TEntity GetById(int id);
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties);
        public TEntity Add(TEntity entity);
        public void Delete(int id);
        public TEntity Update(TEntity entity);
    }
}
