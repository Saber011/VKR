namespace JWT.Requests
{
    /// <summary>
    /// запрос на добавление пользователя
    /// </summary>
    public class ActionTeamRequest
    {
        /// <summary>
        /// id пользователя
        /// </summary>
        public int IdUser { get; set; }
        
        /// <summary>
        /// id команды
        /// </summary>
        public int IdTeam { get; set; }
    }
}
