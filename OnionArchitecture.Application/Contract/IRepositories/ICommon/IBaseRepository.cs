using Microsoft.EntityFrameworkCore.Query;
using OnionArchitecture.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Contract.IRepositories.ICommon
{
    public interface IBaseRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
