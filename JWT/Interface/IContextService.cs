using JWT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWT.Service
{
    /// <summary>
    /// сервис для работы с задачами
    /// </summary>
    public interface IContextService
    {
        /// <summary>
        /// Получить все задачи
        /// </summary>
        Task<List<Exercises>> GetAllAsync();

        /// <summary>
        /// Получить все темы
        /// </summary>
        Task<List<Topics>> GetAllTopicsAsync();

        /// <summary>
        /// Поиск по id
        /// </summary>
        /// <param name="id"></param>
        Task<Exercises> GetByIdAsync(int id);

        /// <summary>
        /// Создание задачи
        /// </summary>
        /// <param name="exercises"></param>
        Task<Exercises> CreateAsync(Exercises exercises);

        /// <summary>
        /// Удаление задачи
        /// </summary>
        /// <param name="id"></param>
        Task<dynamic> DeleteAsync(int id);

        /// <summary>
        /// Редактирование задачи
        /// </summary>
        /// <param name="exercises"></param>
        Task<dynamic> EditAsync(Exercises exercises);

        /// <summary>
        /// Получить следующую задачу для пользователя
        /// </summary>
        /// <param name="id"></param>
        Task<Exercises> GetNextTaskAsync(int id);

        /// <summary>
        /// Получить все задачи по категории
        /// </summary>
        /// <param name="id"></param>
        Task<Exercises[]> GetAllIssuesAcategoryAsync(int id);

        /// <summary>
        /// Проверить верность ответа на задачу
        /// </summary>
        /// <param name="id">Id задачи </param>
        /// <param name="userAnswer">Пользовательские ответы</param>
        /// <param name="userId">Индификтор пользвателя</param>
        Task<bool> GetAnswerAsync(int id, string userAnswer, int userId);

    }
}
