using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreelaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreelaAPI.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel createUserModel)
        {
            return CreatedAtAction(nameof(GetById), new {id = 1}, createUserModel);
        }

        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
        return NoContent();    
        }
    }
}