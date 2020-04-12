﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    /// <summary>
    /// Юзеры
    /// </summary>
    public class User
    {
        /// <summary>
        /// ID юзера
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]

        /// <summary>
        /// Никнейм юзера
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль юзера
        /// </summary>
        public string Password { get; set; }
    }
}
