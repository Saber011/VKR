using JWT.Models;
using System.ComponentModel.DataAnnotations;

namespace JWT.Request
{
    /// <summary>
    /// Запрос пользователя
    /// </summary>
    public sealed class UserModelRequest
    {
        /// <summary>
        /// ID юзера
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Никнейм юзера
        /// </summary>
        [Required]
        public string Login { get; set; }

        public static explicit operator UserModelRequest(User user)
        {
            if (user == null)
                return null;
            UserModelRequest userModelRequest = new UserModelRequest() { Id = user.Id, Login = user.Login };
            return userModelRequest;
        }
    }
}
