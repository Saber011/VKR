using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserTeams> UserTeams {get;set;}
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Level1> Level1 { get; set; }
        public DbSet<Level2> Level2 { get; set; }
        public DbSet<Level3> Level3 { get; set; }
        public DbSet<Levels> Levels { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Topics> Topics { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Login);      //Создание альтернативных ключей
            modelBuilder.Entity<Tasks>().HasAlternateKey(u => u.TextTask);
            modelBuilder.Entity<Team>().HasAlternateKey(u => u.TeamName);
            modelBuilder.Entity<Role>().HasAlternateKey(u => u.NameRole);
            modelBuilder.Entity<Levels>().HasAlternateKey(u => u.LevelName);

            modelBuilder.Entity<UserRoles>().Property(u => u.RoleIdRole).HasDefaultValue(1);

        }

    }
}
