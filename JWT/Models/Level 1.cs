using System.ComponentModel.DataAnnotations;

namespace JWT.Models
{

    /// <summary>
    /// 1 Уровень тем, наивысший
    /// </summary>
    public sealed class Level1
    {
        /// <summary>
        /// ID юзера
        /// </summary>
        [Key]
        public int Level1Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int A { get; set; }
    }
}
