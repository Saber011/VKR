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
            public string Login { get; set; }

            /// <summary>
            /// ID журнала
            /// </summary>
            public string TeamName { get; set; }

            /// <summary>
            /// ID журнала
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// ID команды, вторичный ключ связан с полем IdTeam таблицы Team
            /// </summary>
            public int IdTeam { get; set; }

    }
}
