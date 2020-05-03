using JWT.Core;
using System.Threading.Tasks;

namespace JWT.Interface
{
    /// <summary>
    /// Сервис для сохранения ошибок
    /// </summary>
    public interface IErrorService
    {
        /// <summary>
        /// Зарегестрировать ошибку
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        Task<string> RegisterError(System.Exception ex);

        /// <summary>
        /// Зарегистировать ошибку пользователем
        /// </summary>
        Task<string> SaveSystemErrorByUser(ServiceResponse<object> serviceResponse);

        /// <summary>
        /// Зарегистировать ощибку
        /// </summary>
        Task<string> RegisterError(string errorText);
    }
}
