using System.ComponentModel.DataAnnotations;

namespace JWT.Models
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class aExercises
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int IdExercises { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdTest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NameExercises { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TextExercises { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string AnswerExercises { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int LevelExercises { get; set; }
    }
}
