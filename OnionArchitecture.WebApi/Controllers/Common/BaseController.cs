using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Contract.IFeatures.ICommon;
using OnionArchitecture.Domain.Models.Common;
using OnionArchitecture.Persistence.Context;

namespace OnionArchitecture.WebApi.Controllers.Common
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public abstract class BaseController<TEntity, TGetDto, TCreateDto, TUpdateDto> : ControllerBase
    where TEntity : BaseModel
    where TGetDto : class
    where TCreateDto : class
    where TUpdateDto : class
    {
        protected readonly IBaseService<TEntity, TGetDto, TCreateDto, TUpdateDto> _service;
        protected BaseController(IBaseService<TEntity, TGetDto, TCreateDto, TUpdateDto> service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TCreateDto createDto)
        {
            return Created("Created", await _service.CreateAsync(createDto));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TUpdateDto updateDto)
        {
            await _service.UpdateAsync(id, updateDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
