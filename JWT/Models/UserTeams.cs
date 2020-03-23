using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class UserTeams
    {
        [Key]
        public int UserTeamId { get; set; }
        public int TeamIdTeam { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Team Team { get; set; }
    }
}
