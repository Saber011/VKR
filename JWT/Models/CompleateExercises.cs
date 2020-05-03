using System.ComponentModel.DataAnnotations;

namespace JWT.Models

{
    /// <summary>
    /// Журнал ролей
    /// </summary>
    public sealed class CompleateExercises
    {
        /// <summary>
        /// ID Usera вторичный ключ связан с полем Id таблицы User
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// ID юзера, вторичный ключ связан с полем IdTask таблицы Exercises
        /// </summary>
        public int IdTask { get; set; }
    }
}
