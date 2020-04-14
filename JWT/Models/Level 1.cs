using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{

    /// <summary>
    /// 1 Уровень тем, наивысший
    /// </summary>
    public class Level1
    {
        /// <summary>
        /// ID юзера
        /// </summary>
        [Key]
        public int Level1Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int A { get; set; }
    }
}
