using System.Threading.Tasks;
using API.Repositories;
using Business.Abstract;
using Business.Models;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController :ControllerRepository<IUserService,UserDto>
    {
        private readonly IUserService _service;

        public UsersController(IUserService service) : base(service)
        {
            _service = service;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAll([FromQuery] Filter filter)
        {
            var entities = await _service.GetAllAsync(filter);
            return Ok(entities);
        }
        
    }
}