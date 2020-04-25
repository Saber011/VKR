using System.ComponentModel.DataAnnotations;

namespace JWT.Request
{
    /// <summary>
    /// Запрос на изменения пароля
    /// </summary>
    public class ResetPasswordRequest
    {
        /// <summary>
        /// Индификатор пользвателя
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Новый пароль
        /// </summary>
        [Required]
        public string NewPasswrod { get; set; }
    }
}
