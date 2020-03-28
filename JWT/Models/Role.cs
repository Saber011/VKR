using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class Role
    {
       [Key]
       public int IdRole { get; set; }
       [Required]
       public string NameRole { get; set; }
    }
}
