using JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Service
{
   /// <summary>
   /// сервис для работы с пользователями
   /// </summary>
   public interface IUserService
    {

        /// <summary>
        /// Поиск по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetById(int id);

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User Create(User user, string password);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);


    }
}
