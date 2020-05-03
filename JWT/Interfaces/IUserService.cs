using JWT.Models;
using JWT.Request;
using System.Threading.Tasks;

namespace JWT.Interface
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
        Task<UserModelRequest> GetByIdAsync(int id);

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="user">параметры запроса</param>
        Task<User> CreateAsync(UserRequest user);

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
        Task<dynamic> ResetPasswordAsync(int id, string newPassword);

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        Task<UserModelRequest[]> GetAllUsersAsync();

        /// <summary>
        /// Получить токен
        /// </summary>
        /// <param name="request">параметры запроса</param>
        /// <returns>Возращает токен</returns>
        Task<dynamic> Login(UserRequest request);
    }
}
