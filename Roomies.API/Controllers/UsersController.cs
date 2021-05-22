using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roomies.API.Domain.Models;
using Roomies.API.Domain.Services;
using Roomies.API.Extensions;
using Roomies.API.Resources;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Controllers
{
 
        [Route("/api/[controller]")]
        [Produces("application/json")]
        [ApiController]
        public class UsersController : ControllerBase
        {
            private readonly IUserService _userService;
            private readonly IMapper _mapper;

            public UsersController(IUserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }

            [SwaggerOperation(
               Summary = "List all Users",
               Description = "List of Users",
               OperationId = "ListAllUsers"
               )]
            [SwaggerResponse(200, "List of Users", typeof(IEnumerable<UserResource>))]
            [HttpGet]
            public async Task<IEnumerable<UserResource>> GetAllAsync()
            {
                var users = await _userService.ListAsync();
                var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

                return resources;
            }
            [HttpGet("{id}")]
            [ProducesResponseType(typeof(UserResource), 200)]
            [ProducesResponseType(typeof(BadRequestResult), 404)]
            public async Task<IActionResult> GetAsync(int id)
            {
                var result = await _userService.GetByIdAsync(id);

                if (!result.Success)
                    return BadRequest(result.Message);

                var userResource = _mapper.Map<User, UserResource>(result.Resource);
                return Ok(userResource);
            }
            //---------------------------

        [HttpPost("plans/{planId}/users")]

        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource,int planId)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

                var user = _mapper.Map<SaveUserResource, User>(resource);
                var result = await _userService.SaveAsync(user,planId);

                if (!result.Success)
                    return BadRequest(result.Message);

                var userResource = _mapper.Map<User, UserResource>(result.Resource);

                return Ok(userResource);
            }
            //-------------
            [HttpPut("{id}")]
            public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

                var user = _mapper.Map<SaveUserResource, User>(resource);
                var result = await _userService.UpdateAsync(id, user);

                if (!result.Success)
                    return BadRequest(result.Message);

                var userResource = _mapper.Map<User, UserResource>(result.Resource);

                return Ok(userResource);

            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAsync(int id)
            {
                var result = await _userService.DeleteAsync(id);

                if (!result.Success)
                    return BadRequest(result.Message);

                var userResource = _mapper.Map<User, UserResource>(result.Resource);

                return Ok(userResource);

            }

        }
    
}
