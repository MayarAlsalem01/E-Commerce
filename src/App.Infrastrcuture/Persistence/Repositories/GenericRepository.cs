using App.Applcation.Interfaces.IRepositories.Common;
using App.Domain.Common.Interfaces;
using App.Domain.Specifications.Pagination;
using App.Infrastrcuture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastrcuture.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> Entities { get; set; }= Enumerable.Empty<T>();

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
          await _context.Set<T>().AddAsync(entity,cancellationToken);   
            return entity;
        }

        public bool Any(Expression<Func<T, bool>> expression)=>_context.Set<T>().AsNoTracking().Any(expression);

        public async Task<int> CountAsync(PaginationSpecification specification, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().CountAsync(cancellationToken);
        }

        public async Task<T> DeleteAsync(T entity)
        {
             _context.Set<T>().Remove(entity);
            return entity;
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
            
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity=await _context.Set<T>().FindAsync(id);
           
            return entity;
        }

        public async Task<IEnumerable<T>> GetBySpecificationAsync(PaginationSpecification specification, CancellationToken cancellationToken)
        {
            return await _context.Set<T>()
                            .Skip((specification.PageNumber - 1) * specification.PageSize)
                            .Take(specification.PageSize)
                            .ToListAsync(cancellationToken);
        }

        public  T Update(T entity)
        {
            var task = _context.Set<T>().Update(entity);

            _context.Set<T>().Update(entity);
            return entity;
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
    }
}
