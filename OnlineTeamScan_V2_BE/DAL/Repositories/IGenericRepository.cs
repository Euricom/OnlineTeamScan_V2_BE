using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IGenericRepository<TEntity, TReadDto, TCreateDto, TUpdateDto>
        where TEntity : class
        where TReadDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        public TReadDto GetById(int id);
        public IEnumerable<TReadDto> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties);
        public TReadDto Add(TCreateDto createDto);
        public void Delete(int id);
        public TReadDto Update(TUpdateDto updateDto);
        //public void SaveChanges();
    }
}
