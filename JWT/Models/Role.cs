using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    /// <summary>
    /// Роли
    /// </summary>
    public class Role
    {
       /// <summary>
       /// ID роли
       /// </summary>
       [Key]
       public int IdRole { get; set; }

       /// <summary>
       /// Наименование роли
       /// </summary>
       [Required]
       public string NameRole { get; set; }
    }
}
