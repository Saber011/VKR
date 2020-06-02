using System.ComponentModel.DataAnnotations;

namespace JWT.Models
{
    /// <summary>
    /// Вью юзера и его команды
    /// </summary>
    public sealed class UsersTeams
    {
        /// <summary>
        /// ID журнала
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID журнала
        /// </summary>
        public int Login { get; set; }

        /// <summary>
        /// ID журнала
        /// </summary>
        public int IdTeam { get; set; }

        /// <summary>
        /// ID журнала
        /// </summary>
        public int TeamName { get; set; }

        /// <summary>
        /// ID журнала
        /// </summary>
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
