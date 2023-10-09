using App.Domain.Common.Interfaces;
using App.Domain.Specifications.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Interfaces.IRepositories.Common
{
    public interface IGenericRepository<T> where T : class,IEntity
    {
        IEnumerable<T> Entities { get; }

        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        T Update(T entity );
        Task<T> DeleteAsync(T entity);
        IEnumerable<T> Where(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
        Task<int> CountAsync(PaginationSpecification specification, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetBySpecificationAsync(PaginationSpecification specification, CancellationToken cancellationToken);
    }
}
