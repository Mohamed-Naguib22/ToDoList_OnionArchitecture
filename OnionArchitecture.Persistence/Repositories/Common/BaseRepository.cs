using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OnionArchitecture.Application.Contract.IRepositories.ICommon;
using OnionArchitecture.Domain.Models.Common;
using OnionArchitecture.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Repositories.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected readonly OnionArchitectureContext _context;
        private readonly DbSet<T> Entities;
        public BaseRepository(OnionArchitectureContext context) 
        {
            _context = context;
            Entities = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Entities.FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = Entities.AsQueryable();
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            var query = Entities.AsQueryable();
            return await query.Where(predicate).ToListAsync();
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = Entities.AsQueryable();
            if (include != null) query = include(query);
            return await query.FirstOrDefaultAsync(predicate);
        }
        public async Task<T> AddAsync(T entity)
        {
            entity.ID = Guid.NewGuid();
            await Entities.AddAsync(entity);
            return entity;
        }
        public void Update(T entity)
        {
            entity.DateUpdated = DateTimeOffset.Now;    
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            Entities.Update(entity);
        }
        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DateDeleted = DateTimeOffset.Now;
            _context.Entry(entity).State = EntityState.Deleted;
            Entities.Update(entity);
        }
    }
}
