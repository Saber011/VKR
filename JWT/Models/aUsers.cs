using System.ComponentModel.DataAnnotations;

namespace JWT.Models
{
    /// <summary>
    /// Юзеры
    /// </summary>
    public sealed class aUsers
    {
        /// <summary>
        /// ID юзера
        /// </summary>
        [Key]
        public int IdUser { get; set; }

        /// <summary>
        /// Никнейм юзера
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль юзера
        /// </summary>
        public string Password { get; set; }
    }
}
