using System.ComponentModel.DataAnnotations;

namespace JWT.Models
{
    /// <summary>
    /// Задачи команд
    /// </summary>
    public class ExercisesTeams
    {
        /// <summary>
        /// ID журнала задач команд
        /// </summary>
        [Key]
        public int IdExercisesTeams { get; set; }

        /// <summary>
        /// ID команды, вторичный ключ связан с полем IdTeam таблицы Team
        /// </summary>
        public int IdTeam { get; set; }

        /// <summary>
        /// ID задачи, вторичный ключ связан с полем IdTask таблицы Exercises
        /// </summary>
        public int IdTask { get; set; }
    }
}
