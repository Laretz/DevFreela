using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DevFreela.Core.Entities;


namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project> 
            {
                new Project("Meu projeto ASPNET Core 1", "Minha descrição de projeto 1", 1, 1, 1000),
                new Project("Meu projeto ASPNET Core 2", "Minha descrição de projeto 2", 2, 2, 2000),
                new Project("Meu projeto ASPNET Core 3", "Minha descrição de projeto 3", 3, 3, 3000)
            };

            Users = new List<User> 
            {
                new User("Angeliquinha", "Angeliquinha@gmail.com", new DateTime(2001, 26, 03)),
                new User("Renato", "Renato@gmail.com", new DateTime(30 , 04, 1997)),
                new User("User", "User@gmail.com", new DateTime(2015, 1, 1))
            };
            
            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL")
            };

        }
      
        public List<Project> Projects  { get; private set; }
        public List<User> Users  { get; private set; }
        public List<Skill> Skills  { get; private set; }
        public List<ProjectComment> ProjectComments { get; private set; }
        
    }
}