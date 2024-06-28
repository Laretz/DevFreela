using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base (options)
        {
   

        }
      
        public DbSet<Project> Projects  { get; private set; }
        public DbSet<User> Users  { get; private set; }
        public DbSet<Skill> Skills  { get; private set; }
        public DbSet<UserSkill> UserSkills  { get; private set; }
        public DbSet<ProjectComment> ProjectComments { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}