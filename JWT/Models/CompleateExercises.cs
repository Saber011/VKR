using System.ComponentModel.DataAnnotations;

namespace JWT.Models

{
    /// <summary>
    /// Журнал ролей
    /// </summary>
    public class CompleateExercises
    {
        /// <summary>
        /// ID журнала выполненных задач, является первичным ключом
        /// </summary>
        [Key]
        public int CompleateId { get; set; }
        /// <summary>
        /// ID Usera вторичный ключ связан с полем Id таблицы User
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// ID юзера, вторичный ключ связан с полем IdTask таблицы Exercises
        /// </summary>
        public int IdTask { get; set; }
    }
}
