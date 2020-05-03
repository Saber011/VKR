using System.ComponentModel.DataAnnotations;

namespace JWT.Request
{
    /// <summary>
    /// Запрос на проверку ответа
    /// </summary>
    public sealed class CheackTaskRequest
    {
        /// <summary>
        /// Индификатор задачи
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Ответ пользователя
        /// </summary>
        [Required]
        public string UserAnswer { get; set; }

        /// <summary>
        /// Индификатор Пользователя
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Язык
        /// </summary>
        [Required]
        public string Language { get; set; }

        /// <summary>
        /// Версия языка
        /// </summary>
        [Required]
        public string VersionIndex { get; set; }

    }
}
