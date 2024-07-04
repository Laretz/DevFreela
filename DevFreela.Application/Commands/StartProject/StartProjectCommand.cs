using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommand : IRequest<int>
    {
         public StartProjectCommand(int _id)
        {
            Id = _id;
        }

        public int Id { get; private set; } 
    }
}