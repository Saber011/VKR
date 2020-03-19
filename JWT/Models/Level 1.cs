using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class Level1
    {
        [Key]
        public int Id { get; set; }
        public string A { get; set; }
    }
}
