using System.ComponentModel.DataAnnotations;

namespace JWT.Models
{
    /// <summary>
    /// Журнал привязки юзера к команде
    /// </summary>
    public class UserTeams
    {
        /// <summary>
        /// ID журнала
        /// </summary>
        [Key]
        public int UserTeamId { get; set; }

        /// <summary>
        /// ID команды, вторичный ключ связан с полем IdTeam таблицы Team
        /// </summary>
        public int TeamIdTeam { get; set; }

        /// <summary>
        /// ID юзера, вторичный ключ связан с полем Id таблицы User
        /// </summary>
        public int UserId { get; set; }
    }
}
