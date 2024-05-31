using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using OnionArchitecture.Application.Contract.IFeatures.ICommon;
using OnionArchitecture.Application.Contract.IRepositories.ICommon;
using OnionArchitecture.Application.Exceptions;
using OnionArchitecture.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Features_Imp.Common
{
    public class BaseService<TEntity, TGetDto, TCreateDto, TUpdateDto> : IBaseService<TEntity,TGetDto, TCreateDto, TUpdateDto>
    where TEntity : BaseModel
    where TGetDto : class
    where TCreateDto : class
    where TUpdateDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TGetDto> GetByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);
            return entity == null ? throw new EntityNotFoundException() : _mapper.Map<TGetDto>(entity);
        }
        public async Task<IEnumerable<TGetDto>> GetAllAsync()
        {
            var entity = await _unitOfWork.GetRepository<TEntity>().GetAllAsync(x => !x.IsDeleted);
            return _mapper.Map<IEnumerable<TGetDto>>(entity);
        }
        public async Task<TEntity> CreateAsync(TCreateDto createDto)
        {
            var entity = _mapper.Map<TEntity>(createDto);
            await _unitOfWork.GetRepository<TEntity>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(Guid id, TUpdateDto updateDto)
        {
            var entity = await _unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);
            _mapper.Map(updateDto, entity);
            _unitOfWork.GetRepository<TEntity>().Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);
            _unitOfWork.GetRepository<TEntity>().Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<TEntity> GetByPropertiesAsync(Dictionary<string, object> propertyValues, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var lambda = BuildLambdaExpression(propertyValues);

            var entity = await _unitOfWork.GetRepository<TEntity>().FirstOrDefaultAsync(lambda, include);

            if (entity is null)
            {
                throw new EntityNotFoundException("Entity");
            }

            return entity;

        }
        private Expression<Func<TEntity, bool>> BuildLambdaExpression(Dictionary<string, object> propertyValues)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            Expression body = null;

            foreach (var kvp in propertyValues)
            {
                var property = Expression.Property(parameter, kvp.Key);
                var value = Expression.Constant(kvp.Value);
                var equal = Expression.Equal(property, value);

                body = body == null ? equal : Expression.AndAlso(body, equal);
            }

            return Expression.Lambda<Func<TEntity, bool>>(body, parameter);
        }
    }
}
