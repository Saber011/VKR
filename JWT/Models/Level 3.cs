using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class Level3
    {
        [Key]
        public int Level3Id { get; set; }
        [Required]
        public int D { get; set; }
        [Required]
        public int E { get; set; }
        [Required]
        public int F { get; set; }
        [Required]
        public int G { get; set; }        
        public User User { get; set; }

    }
}
