using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Queries.GetUsers;
using DevFreelaAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreelaAPI.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

           // api/users/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserQuery(id);

            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        //api/users
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel createUserModel)
        {
            return CreatedAtAction(nameof(GetById), new {id = 1}, createUserModel);
        }

        //api/users/1/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
        return NoContent();    
        }
    }
}