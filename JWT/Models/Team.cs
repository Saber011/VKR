using System.ComponentModel.DataAnnotations;

namespace JWT.Models
{
    /// <summary>
    /// Команды
    /// </summary>
    public class Team
    {
        /// <summary>
        /// ID команды
        /// </summary>
        [Key]
        public int IdTeam { get; set; }

        /// <summary>
        /// Название команды
        /// </summary>
        [Required]
        public string TeamName { get; set; }

        /// <summary>
        /// ID капитана команды, вторичный ключ связан с полем Id таблицы User
        /// </summary>
        public int CapId { get; set; }
        /// <summary>
        /// ID тренера команды, вторичный ключ связан с полем Id таблицы User
        /// </summary>
        public int CoachId { get; set; }
        
        /// <summary>
        /// Рейтинг команды
        /// </summary>
        public int TeamRating { get; set; }
    }
}
