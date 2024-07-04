using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace DevFreela.Application.Commands.CreateProjects
{
    public class CreateProjectCommand : IRequest <int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdCliente { get; set; }
        public int IdFreeLancer { get; set; }
        public decimal TotalCost { get; set; }
    }
}
