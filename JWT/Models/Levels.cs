using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class Levels
    {
        [Key]
        public int IdLevel { get; set; }
        public string LevelName { get; set; }
    }
}