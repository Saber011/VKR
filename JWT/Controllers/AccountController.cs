using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using JWT.Models;
using JWT.Service;
using JWT.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWT.Controllers
{
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private ApplicationContext db;
        private IUserService _userService;
        public AccountController(ApplicationContext context, IUserService userService)
        {
            _userService = userService;
            db = context;
        }



        /// <summary>
        /// Получить пользователя
        /// </summary>
        /// <param name="id">Индификтор пользвателя</param>
        /// <returns>Найденный пользватель</returns>
        [HttpGet("GetUserById")]
        public User GetUser(int id)
        {
           return _userService.GetById(id);
        }

        /// <summary>
        /// Удалить пользвателя
        /// </summary>
        /// <param name="id">Индефикатор пользователя</param>
        [HttpGet("DeleteUser")]
        public  Task DeleteUser(int id)
        {
            return _userService.DeleteAsync(id);
        }


        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
        }


        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userView"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserView userView)
        {

            var user = new User { Id = userView.Id, Login = userView.Login };
            try
            {
                // save 
                _userService.Create(user, userView.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            User person = db.Users.FirstOrDefault(x => x.Login == username);

            /* Fetch the stored value */
            string savedPasswordHash =person.Password;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    throw new AppException("Invalid username or password");
            if (person != null)
                {
                    var firstUserRoles = db.UserRoles.FirstOrDefault(x => x.UserId == person.Id);
                    var roles = db.Roles.FirstOrDefault(x => x.IdRole == firstUserRoles.RoleIdRole);

                    var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, roles.NameRole)
                };
                    ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                    return claimsIdentity;
                }

            
            // если пользователя не найдено
            return null;
        }
    }
}