using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Core.Exceptions
{
    public class ProjectedAlreadyCreatedException : Exception
    {
        public ProjectedAlreadyCreatedException() : base ("Projected is Already in Started Status")
        {
            
        }
    }
}