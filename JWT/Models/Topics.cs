using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class Topics
    {
        [Key]
        public int IdTopic { get; set; }
        public int LevelsIdLevel { get; set; }
    }
}
