using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class Level1
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int A { get; set; }
    
        public User User { get; set; }
    }
}
