using Microsoft.EntityFrameworkCore.Query;
using OnionArchitecture.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Contract.IFeatures.ICommon
{
    public interface IBaseService<TEntity, TGetDto, TCreateDto, TUpdateDto>
    where TEntity : BaseModel
    where TGetDto : class
    where TCreateDto : class
    where TUpdateDto : class
    {
        Task<TGetDto> GetByIdAsync(Guid id);
        Task<IEnumerable<TGetDto>> GetAllAsync();
        //Task<TEntity> FirstOrDefaultAsync(Dictionary<string, object> propertyValues,
        //    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<TEntity> CreateAsync(TCreateDto createDto);
        Task UpdateAsync(Guid id, TUpdateDto updateDto);
        Task DeleteAsync(Guid id);
    }
}
