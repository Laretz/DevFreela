using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommand :IRequest<Unit>
    {
        public DeleteProjectCommand(int _id)
        {
            Id = _id;
        }

        public int Id { get; private set; }
    }
}