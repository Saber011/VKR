using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int MMR { get; set; }
    }
}
