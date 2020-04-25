using JWT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWT.Service
{

    /// <summary>
    /// Сервис для работы с командами
    /// </summary>
    public interface ITeamService
    {

        /// <summary>
        /// Получить все команды
        /// </summary>
        /// <returns></returns>
        Task<List<Team>> GetAllTeamsAsync();

        /// <summary>
        /// Поиск команды по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Team> FindTeamAsync(int id);

        /// <summary>
        /// Создание команды
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        Task<Team> CreateAsync(Team team);

        /// <summary>
        /// Удаление команды
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<dynamic> DeleteAsync(int id);

        /// <summary>
        /// Редактирование данных команды
        /// </summary>
        /// <returns></returns>
        Task<dynamic> EditAsync(Team team);
    }
}