using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreelaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly OpeningTimeOption _option;
        public ProjectController(IOptions<OpeningTimeOption> option, ExampleClass exampleClass)
        {
            exampleClass.Name = "Updated at Project";
            _option = option.Value;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject){
            if(createProject.Title.Length >50){
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById), new {id = createProject.Id}, createProject);
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
        {
             if(updateProject.Description.Length > 200){
                return BadRequest();
            }
            return NoContent();
        }

        // api/projects/3 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

        // api/projects/1/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createComment){
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id){
            return NoContent();
        }
    }
}