using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class UserRoles
    {
        [Key]
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        [Required]
        public int RoleIdRole { get; set; }
    }
}
