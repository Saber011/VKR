using System.ComponentModel.DataAnnotations;

namespace JWT.Request
{
    /// <summary>
    /// Запрос на создание пользователя
    /// </summary>
    public sealed class UserRequest
    {
        /// <summary>
        /// Логин
        /// </summary>
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        public string Password { get; set; }

    }
}
