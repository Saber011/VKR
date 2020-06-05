using System.ComponentModel.DataAnnotations;

namespace JWT.Models
{
    /// <summary>
    /// Юзеры
    /// </summary>
    public sealed class User
    {
        /// <summary>
        /// ID юзера
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]

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
