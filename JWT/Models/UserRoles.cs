using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
    
{
    /// <summary>
    /// Журнал ролей
    /// </summary>
    public class UserRoles
    {
        /// <summary>
        /// ID журнала
        /// </summary>
        [Key]
        public int UserRoleId { get; set; }

        /// <summary>
        /// ID юзера
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// ID роли
        /// </summary>
        [Required]
        public int RoleIdRole { get; set; }
    }
}
