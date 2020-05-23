using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JWT.Models
{
    /// <summary>
    /// Работа с бд
    /// </summary>
    public sealed class ApplicationContext : DbContext
    {
        /// <summary>
        /// Юзеры 
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Роли
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Команды
        /// </summary>
        public DbSet<Team> Teams { get; set; }

        /// <summary>
        /// Журнал привязки юзера к команде
        /// </summary>
        public DbSet<UserTeams> UserTeams { get; set; }

        /// <summary>
        /// Журнал ролей
        /// </summary>
        public DbSet<UserRoles> UserRoles { get; set; }

        /// <summary>
        /// 1 Уровень тем, наивысший
        /// </summary>
        public DbSet<Level1> Level1 { get; set; }

        /// <summary>
        /// 2 Уровень тем, средний
        /// </summary>
        public DbSet<Level2> Level2 { get; set; }

        /// <summary>
        /// 3 Уровень тем, легкий
        /// </summary>
        public DbSet<Level3> Level3 { get; set; }

        /// <summary>
        /// Задачи
        /// </summary>
        public DbSet<Exercises> Exercises { get; set; }

        /// <summary>
        /// Темы
        /// </summary>
        public DbSet<Topics> Topics { get; set; }

        /// <summary>
        /// Задачи от тренера
        /// </summary>
        public DbSet<ExercisesTeams> ExercisesTeamss { get; set; }
        /// <summary>
        /// Журнал решенных пользовательских задач
        /// </summary>
        public DbSet<ExercisesTeams> CompleateExercises { get; set; }





        public DbSet<aTests> aTests { get; set; }
        public DbSet<aSubjects> aSubjects { get; set; }
        public DbSet<aHierarchySubjectsUsers> aHierarchySubjectsUsers { get; set; }
        public DbSet<aExercises> aExercises { get; set; }
        public DbSet<aCompleateExercises> aCompleateExercises { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();

        });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<aCompleateExercises>()
       .HasNoKey();
            modelBuilder.Entity<aHierarchySubjectsUsers>()
       .HasNoKey();
            modelBuilder.Entity<aHierarchySubjectsUsers>()
.HasNoKey();
            // Создание альтернативных ключей
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Login);
            modelBuilder.Entity<Exercises>().HasAlternateKey(u => u.TextTask);
            modelBuilder.Entity<Team>().HasAlternateKey(u => u.TeamName);
            modelBuilder.Entity<Role>().HasAlternateKey(u => u.NameRole);

            // Создание дефолтных значений
            modelBuilder.Entity<UserRoles>().Property(u => u.RoleIdRole).HasDefaultValue(1);
            modelBuilder.Entity<Level1>().Property(u => u.A).HasDefaultValue(0);
            modelBuilder.Entity<Level2>().Property(u => u.B).HasDefaultValue(0);
            modelBuilder.Entity<Level2>().Property(u => u.C).HasDefaultValue(0);
            modelBuilder.Entity<Level3>().Property(u => u.D).HasDefaultValue(0);
            modelBuilder.Entity<Level3>().Property(u => u.E).HasDefaultValue(0);
            modelBuilder.Entity<Level3>().Property(u => u.F).HasDefaultValue(0);
            modelBuilder.Entity<Level3>().Property(u => u.G).HasDefaultValue(0);
            modelBuilder.Entity<Team>().Property(u => u.TeamRating).HasDefaultValue(0);
        }

    }
}
