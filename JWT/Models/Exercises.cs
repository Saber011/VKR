using System.ComponentModel.DataAnnotations;

namespace JWT.Models
{
    /// <summary>
    /// Задачи
    /// </summary>
    public sealed class Exercises
    {
        /// <summary>
        /// ID задачи
        /// </summary>
        [Key]
        public int IdTask { get; set; }

        /// <summary>
        /// ID темы, вторичный ключ связан с полем IdTopic таблицы Topics
        /// </summary>
        public int TopicsId { get; set; }

        /// <summary>
        /// Уровень задачи
        /// </summary>
        [Required]
        public int Level { get; set; }

        /// <summary>
        /// Текст задачи
        /// </summary>
        [Required]
        public string TextTask { get; set; }

        /// <summary>
        /// Ответ на задачу
        /// </summary>
        [Required]
        public string AnswerTask { get; set; }
    }
}
