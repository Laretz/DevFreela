using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetProjectsById
{
    public class GetProjectByIdQuery : IRequest<ProjectDetailsViewModel>
    
    {
        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }     
        public int Id { get; private set; }
        
    }
}