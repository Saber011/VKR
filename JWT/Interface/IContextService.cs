using JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        Task<List<Exercises>> GetAll();

        /// <summary>
        /// Поиск по id
        /// </summary>
        /// <param name="id"></param>
        Task<Exercises> GetById(int id);

        /// <summary>
        /// Создание задачи
        /// </summary>
        /// <param name="exercises"></param>
        Task<Exercises> Create(Exercises exercises);

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
         Task<Exercises> GetNextTask(int id);

        /// <summary>
        /// Получить все задачи по категории
        /// </summary>
        /// <param name="id"></param>
        Task<Exercises> GetAllIssuesAcategory(int id);

        /// <summary>
        /// Проверить верность ответа на задачу
        /// </summary>
        /// <param name="id">Id задачи </param>
        /// <param name="userAnswer">Пользовательские ответы</param>
        /// <returns></returns>
        Task<bool> GetAnswer(int id, string userAnswer);

    }
}
