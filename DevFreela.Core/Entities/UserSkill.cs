using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class UserSkill : BaseEntity
    {
        public int IdUser { get; private set; }
        public int IdSkill { get; private set; }
        public Skill Skill { get; private set; }
        
    }
}