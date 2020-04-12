using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{

    /// <summary>
    /// Работа с бд
    /// </summary>
    public class ApplicationContext : DbContext
    {

        /// <summary>
        /// Таблица пользователи
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserTeams> UserTeams {get;set;}
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Level1> Level1 { get; set; }
        public DbSet<Level2> Level2 { get; set; }
        public DbSet<Level3> Level3 { get; set; }
        public DbSet<Levels> Levels { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
        public DbSet<Topics> Topics { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Login);      //Создание альтернативных ключей
            modelBuilder.Entity<Exercises>().HasAlternateKey(u => u.TextTask);
            modelBuilder.Entity<Team>().HasAlternateKey(u => u.TeamName);
            modelBuilder.Entity<Role>().HasAlternateKey(u => u.NameRole);
            modelBuilder.Entity<Levels>().HasAlternateKey(u => u.LevelName);

            modelBuilder.Entity<UserRoles>().Property(u => u.RoleIdRole).HasDefaultValue(1); //Создание дефолтных значений
            modelBuilder.Entity<Level1>().Property(u => u.A).HasDefaultValue(0);
            modelBuilder.Entity<Level2>().Property(u => u.B).HasDefaultValue(0);
            modelBuilder.Entity<Level2>().Property(u => u.C).HasDefaultValue(0);
            modelBuilder.Entity<Level3>().Property(u => u.D).HasDefaultValue(0);
            modelBuilder.Entity<Level3>().Property(u => u.E).HasDefaultValue(0);
            modelBuilder.Entity<Level3>().Property(u => u.F).HasDefaultValue(0);
            modelBuilder.Entity<Level3>().Property(u => u.G).HasDefaultValue(0);
        }

    }
}
