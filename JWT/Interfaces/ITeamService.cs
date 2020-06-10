using JWT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWT.Interface
{
    /// <summary>
    /// Сервис для работы с командами
    /// </summary>
    public interface ITeamService
    {

        /// <summary>
        /// Получить все команды
        /// </summary>
        Task<List<Team>> GetAllTeamsAsync();

        /// <summary>
        /// Поиск команды по id
        /// </summary>
        Task<Team> FindTeamAsync(int id);

        /// <summary>
        /// Создание команды
        /// </summary>
        Task<Team> CreateAsync(Team team);

        /// <summary>
        /// Удаление команды
        /// </summary>
        Task<dynamic> DeleteAsync(int id);

        /// <summary>
        /// Редактирование данных команды
        /// </summary>
        Task<dynamic> EditAsync(Team team);

        /// <summary>
        /// Добавить участника в команду
        /// </summary>
        public Task<dynamic> AddUserToTeam(int IdTeam, int idUser);

        /// <summary>
        /// Получить все команды пользователя
        /// </summary>
        public Task<UsersTeams[]> GetUsersTeams(int idUser);

        /// <summary>
        /// Получить всех участников команды
        /// </summary>
        public Task<UsersTeams[]> GetTeamUser(int idTeam);

        /// <summary>
        /// Удалить участника из команды
        /// </summary>
        public Task<dynamic> RemovUserToTeam(int IdTeam, int idUser);
    }
}