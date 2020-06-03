using System.ComponentModel.DataAnnotations;

namespace JWT.Models
{
    /// <summary>
    /// 2 Уровень тем, средний
    /// </summary>
    public sealed class Level2
    {

        /// <summary>
        /// ID юзера
        /// </summary>
        [Key]
        public int Level2Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// "Название темы", хранит лвл юзера по этой теме
        /// </summary>
        [Required]
        public int B { get; set; }

        /// <summary>
        /// "Название темы", хранит лвл юзера по этой теме
        /// </summary>
        [Required]
        public int C { get; set; }
    }
}
