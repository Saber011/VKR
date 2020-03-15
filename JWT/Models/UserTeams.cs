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
        public int IdTeam { get; set; }
        public int IdUser { get; set; }
    }
}
