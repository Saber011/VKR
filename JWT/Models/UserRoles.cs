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
        public int IdUser { get; set; }
        public int IdRoles { get; set; }
       
    }
}
