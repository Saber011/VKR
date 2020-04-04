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
        /// Поиск всех задачи
        /// </summary>
        /// <returns></returns>
        Task<Tasks> GetAll();

        /// <summary>
        /// Поиск по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Tasks> GetById(int id);

        /// <summary>
        /// Создание задачи
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        Tasks Create(Tasks tasks);

        /// <summary>
        /// Удаление задачи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         Task DeleteAsync(int id);

        /// <summary>
        /// Редактирование задачи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task EditAsync(int id);

        /// <summary>
        /// Получить следующую задачу для пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         Task<Tasks> GetNextTask(int id);
    }
}
