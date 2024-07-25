using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProjects;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectsById;


/* using DevFreela.Application.Services.Interfaces; */
using DevFreela.Application.ViewModels;
using DevFreelaAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        /* private readonly IProjectService _projectService; */
        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
          
            _mediator = mediator;
        }
        
         // api/projects?query=net core
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProjectsQuery = new GetAllProjectsQuery(query);

            var projects = await _mediator.Send(getAllProjectsQuery); 

            return Ok(projects);
        }

         // api/projects/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command){
            if(!ModelState.IsValid)
            {
               
                return BadRequest(); 
            }
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new {id = id}, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 200){
                return BadRequest();
            }
            await _mediator.Send(command);
            return NoContent();
        }

        // api/projects/3 DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command){
            
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task <IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public async Task <IActionResult> Finish(int id){
            var command = new FinishProjectCommand(id);
            
            await _mediator.Send(command);
            return NoContent();
        }
    }
}