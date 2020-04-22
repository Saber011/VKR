using JWT.Models;
using JWT.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Request
{
    public class UserModelRequest
    {
        /// <summary>
        /// ID юзера
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Никнейм юзера
        /// </summary>
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
