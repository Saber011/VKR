using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWT.Models
{
    /// <summary>
    /// Юзеры
    /// </summary>
    public sealed class aCompleateExercises
    {
        /// <summary>
        /// ef
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Key { get; set; }

        /// <summary>
        /// ID 
        /// </summary>
        public int IdUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdExercises { get; set; }
    }
}
