using System.ComponentModel.DataAnnotations;

namespace JWT.ViewModel
{
    /// <summary>
    /// Запрос на создание пользователя
    /// </summary>
    public class UserRequest
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
