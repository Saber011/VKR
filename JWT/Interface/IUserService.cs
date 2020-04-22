using JWT.Models;
using JWT.Request;
using JWT.ViewModel;
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
        /// <param name="id">Индификатор пользователя</param>
        /// <returns>Возращает пользвателя</returns>
        Task<UserModelRequest> GetById(int id);

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="user"></param>
        Task<User> Create(UserRequest user);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">Индификатор пользователя</param>
        Task<dynamic> DeleteAsync(int id);

        /// <summary>
        /// Изменить пароль
        /// </summary>
        /// <param name="id">Индификатор пользователя</param>
        /// <param name="newPassword">Новый пароль</param>
        Task<dynamic> ResetPassword(int id, string newPassword);

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        Task<UserModelRequest[]> GetAllUsers();
    }
}
