using System.Threading.Tasks;
using API.Repositories;
using Business.Abstract;
using Business.Models;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserGroupsController :ControllerRepository<IUserGroupService,UserGroupDto>
    {
        private readonly IUserGroupService _service;

        public UserGroupsController(IUserGroupService service) : base(service)
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