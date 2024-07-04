using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandle : IRequestHandler <FinishProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;     
        public FinishProjectCommandHandle (DevFreelaDbContext dbContext)   
        {
            _dbContext = dbContext;
        }
         
    public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await  _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == request.Id);

            project.Finish();
            _dbContext.SaveChanges();

            return Unit.Value;
        }
    }
}