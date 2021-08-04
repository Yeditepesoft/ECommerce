using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Business.Repositories;
using Core.Exceptions;
using Core.Signatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerRepository<TService, TDto> : ControllerBase
        where TService : class, IServiceRepository<TDto>
        where TDto : class, IBaseDto, new()
    {
        public string NotFoundMessage = $"{typeof(TDto).Name} is not found";
        private readonly TService _service;

        public ControllerRepository(TService service)
        {
            _service = service;
        }
        
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _service.GetAsync(id);
            if (result == null) throw new NotFoundException(NotFoundMessage);
            return Ok(result);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Create([FromBody] TDto dto)
        {
            var id = await _service.InsertAsync(dto);
            return CreatedAtAction(null, id);
        }
        
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Update([FromQuery, Required] int id,[FromBody] TDto dto)
        {
            await _service.UpdateAsync(id,dto);
            return StatusCode(204);
        }
        
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return StatusCode(204);
        }
        
        [HttpDelete("DeleteRange")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRange([FromQuery, Required] List<int> listOfId)
        {
            await _service.DeleteRangeAsync(listOfId);
            return StatusCode(204);
        }
        
        [HttpGet("RemoveCache")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public virtual async Task<IActionResult> RemoveCache()
        {
            await _service.RemoveCacheAsync();
            return StatusCode(204);
        }
    }
}