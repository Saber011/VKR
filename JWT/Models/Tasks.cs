using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class Tasks
    {
        [Key]
        public int IdTask { get; set; }
        public int IdTopic { get; set; }
        public int Level { get; set; }
        public string TextTask { get; set; }
        public string AnswerTask { get; set; }
    }
}
