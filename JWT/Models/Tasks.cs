using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class Tasks
    {
        [Key]
        public int IdTask { get; set; }
        public int IdTopic { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public string TextTask { get; set; }
        [Required]
        public string AnswerTask { get; set; }
       
        [ForeignKey("IdTopic")]
        public Topics Topic { get; set; }
    }
}
