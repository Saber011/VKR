using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{

    /// <summary>
    /// Модель для работы с уровнями 
    /// </summary>
    public class Levels
    {


        /// <summary>
        /// Ключ уровня
        /// </summary>
        [Key]
        public int IdLevel { get; set; }

        /// <summary>
        /// Название уровня
        /// </summary>
        [Required]
        public string LevelName { get; set; }
    }
}