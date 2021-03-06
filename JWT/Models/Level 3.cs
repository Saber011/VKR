﻿using System.ComponentModel.DataAnnotations;

namespace JWT.Models
{
    /// <summary>
    /// 3 Уровень тем, легкий
    /// </summary>
    public sealed class Level3
    {
        /// <summary>
        /// ID юзера
        /// </summary>
        [Key]
        public int Level3Id { get; set; }

        /// <summary>
        /// "Название темы", хранит лвл юзера по этой теме
        /// </summary>
        [Required]
        public int D { get; set; }

        /// <summary>
        /// "Название темы", хранит лвл юзера по этой теме
        /// </summary>
        [Required]
        public int E { get; set; }

        /// <summary>
        /// "Название темы", хранит лвл юзера по этой теме
        /// </summary>
        [Required]
        public int F { get; set; }

        /// <summary>
        /// "Название темы", хранит лвл юзера по этой теме
        /// </summary>
        [Required]
        public int G { get; set; }

    }
}
