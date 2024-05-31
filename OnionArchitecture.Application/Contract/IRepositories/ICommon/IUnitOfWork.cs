using OnionArchitecture.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Contract.IRepositories.ICommon
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<T> GetRepository<T>() where T : BaseModel;
        Task SaveChangesAsync();
        public void Dispose();
    }
}
