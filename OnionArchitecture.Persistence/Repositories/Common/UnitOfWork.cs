using OnionArchitecture.Application.Contract.IRepositories.ICommon;
using OnionArchitecture.Domain.Models.Common;
using OnionArchitecture.Domain.Models.Entities;
using OnionArchitecture.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnionArchitectureContext _context;
        public UnitOfWork(OnionArchitectureContext context) 
        {
            _context = context;
        }
        public IBaseRepository<T> GetRepository<T>() where T : BaseModel
        {
            return new BaseRepository<T>(_context);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
