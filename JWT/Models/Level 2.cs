using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    /// <summary>
    /// 2 Уровень тем, средний
    /// </summary>
    public class Level2
    {

        /// <summary>
        /// ID юзера
        /// </summary>
        [Key]
        public int Level2Id { get; set; }

        /// <summary>
        /// "Название темы", хранит лвл юзера по этой теме
        /// </summary>
        [Required]
        public int B { get; set; }

        /// <summary>
        /// "Название темы", хранит лвл юзера по этой теме
        /// </summary>
        [Required]
        public int C { get; set; }
    }
}
