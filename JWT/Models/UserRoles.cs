using System.ComponentModel.DataAnnotations;

namespace JWT.Models
{
    /// <summary>
    /// Журнал ролей
    /// </summary>
    public sealed class UserRoles
    {
        /// <summary>
        /// ID журнала
        /// </summary>
        [Key]
        public int UserRoleId { get; set; }

        /// <summary>
        /// ID юзера, вторичный ключ связан с полем Id таблицы User
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// ID роли, вторичный ключ связан с полем IdRole таблицы Role
        /// </summary>
        [Required]
        public int RoleIdRole { get; set; }
    }
}
