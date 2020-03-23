using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class Team
    {
        [Key]
        public int IdTeam { get; set; }
        [Required]
        public string TeamName { get; set; }
        public int CapId { get; set; }
        public int CoachId { get; set; }       
        public User User  { get; set; }
    }
}
