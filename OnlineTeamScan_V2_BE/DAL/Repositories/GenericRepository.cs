using AutoMapper;
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
    public class GenericRepository<TEntity, TReadDto, TCreateDto, TUpdateDto> : IGenericRepository<TEntity, TReadDto, TCreateDto, TUpdateDto>
        where TEntity : class
        where TReadDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        protected readonly OnlineTeamScanContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IMapper _mapper;

        public GenericRepository(OnlineTeamScanContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _mapper = mapper;
        }

        public TReadDto GetById(int id)
        {
            return _mapper.Map<TReadDto>(_dbSet.Find(id));
        }

        public IEnumerable<TReadDto> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties)
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

            return _mapper.Map<IEnumerable<TReadDto>>(query.AsNoTracking().ToList());
        }       

        public TReadDto Add(TCreateDto createDto)
        {
            var entity = _dbSet.Add(_mapper.Map<TEntity>(createDto));
            SaveChanges();

            return _mapper.Map<TReadDto>(entity.Entity);
        }

        public TReadDto Update(TUpdateDto updateDto)
        {
            var entity = _dbSet.Update(_mapper.Map<TEntity>(updateDto));
            SaveChanges();

            return _mapper.Map<TReadDto>(entity.Entity);
        }

        public void Delete(int id)
        {
            TEntity entity = _dbSet.Find(id);

            _dbSet.Remove(_mapper.Map<TEntity>(entity));
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
