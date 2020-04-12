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
        List<Exercises> GetAll();

        /// <summary>
        /// Поиск по id
        /// </summary>
        /// <param name="id"></param>
        Exercises GetById(int id);

        /// <summary>
        /// Создание задачи
        /// </summary>
        /// <param name="exercises"></param>
        Task Create(Exercises exercises);

        /// <summary>
        /// Удаление задачи
        /// </summary>
        /// <param name="id"></param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Редактирование задачи
        /// </summary>
        /// <param name="exercises"></param>
        Task EditAsync(Exercises exercises);

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
        bool GetAnswer(int id, string userAnswer);

    }
}
