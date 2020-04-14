using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    /// <summary>
    /// Темы
    /// </summary>
    public class Topics
    {
        /// <summary>
        /// ID Темы
        /// </summary>
        [Key]
        public int IdTopic { get; set; }

        /// <summary>
        /// Наименование темы
        /// </summary>
        public string NameTopics { get; set; }

        /// <summary>
        /// Уровень темы, ставим сами от 1 до 3
        /// </summary>
        public int LevelsIdLevel { get; set; }

        /// <summary>
        /// Костыль для сопостовления с темой в левел 1, левел 2, левел 3
        /// </summary>
        public char Kostil { get; set; }
    }
}
