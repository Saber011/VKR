using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    /// <summary>
    /// Задачи
    /// </summary>
    public class Exercises
    {
        /// <summary>
        /// ID задачи
        /// </summary>
        [Key]
        public int IdTask { get; set; }

        /// <summary>
        /// ID темы
        /// </summary>
        public int TopicsId { get; set; }

        /// <summary>
        /// Уровень задачи
        /// </summary>
        [Required]
        public int Level { get; set; }

        /// <summary>
        /// Текст задачи
        /// </summary>
        [Required]
        public string TextTask { get; set; }

        /// <summary>
        /// Ответ на задачу
        /// </summary>
        [Required]
        public string AnswerTask { get; set; }       
    }
}
