using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    /// <summary>
    /// Команды
    /// </summary>
    public class Team
    {
        /// <summary>
        /// ID команды
        /// </summary>
        [Key]
        public int IdTeam { get; set; }

        /// <summary>
        /// Название команды
        /// </summary>
        [Required]
        public string TeamName { get; set; }

        /// <summary>
        /// ID капитана команды, вторичный ключ связан с полем Id таблицы Role
        /// </summary>
        public int CapId { get; set; }
        /// <summary>
        /// ID тренера команды, вторичный ключ связан с полем Id таблицы Role
        /// </summary>
        public int CoachId { get; set; }       
    }
}
