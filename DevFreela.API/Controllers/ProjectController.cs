using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreelaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            
            var project = _projectService.GetById(id);

            if(project == null) return null;

    
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel inputModel){
            if(inputModel.Title.Length >50){
                return BadRequest();
            }

            var id = _projectService.Create(inputModel);
            return CreatedAtAction(nameof(GetById), new {id = id}, inputModel);
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inuputModel)
        {
            if (inuputModel.Description.Length > 200){
                return BadRequest();
            }
            _projectService.Update(inuputModel);
            return NoContent();
        }

        // api/projects/3 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return NoContent();
        }

        // api/projects/1/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel inputModel){

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id){
            _projectService.Finish(id);
            return NoContent();
        }
    }
}