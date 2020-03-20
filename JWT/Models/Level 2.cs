﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class Level2
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int B { get; set; }
        [Required]
        public int C { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}