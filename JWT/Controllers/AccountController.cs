using JWT.Models;
using JWT.Request;
using JWT.Service;
using JWT.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace JWT.Controllers
{
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly ExecuteService _executeService;
        private readonly ApplicationContext db;
        private readonly IUserService _userService;
        public AccountController(
            ApplicationContext context,
            IUserService userService,
            ExecuteService executeService)
        {
            _userService = userService;
            db = context;
            _executeService = executeService;
        }

        /// <summary>
        /// Получить пользователя
        /// </summary>
        /// <param name = "id" > Индификтор пользвателя</param>
        /// <returns>Найденный пользватель</returns>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpPost("GetUserById")]
        public async Task<ServiceResponse<UserModelRequest>> GetUser(int id)
        {
            return await _executeService.TryExecute(() => _userService.GetById(id));
        }

        /// <summary>
        /// Получить всех пользвателей
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response>
        [HttpGet("GetAllUsers")]
        public async Task<ServiceResponse<UserModelRequest[]>> GetAllUsers()
        {
            return await _executeService.TryExecute(() => _userService.GetAllUsers());
        }

        /// <summary>
        /// Удалить пользвателя
        /// </summary>
        /// <param name="id">Индефикатор пользователя</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response>
        [HttpGet("DeleteUser")]
        public async Task<ServiceResponse<dynamic>> DeleteUser(int id)
        {
            return await _executeService.TryExecute(() => _userService.DeleteAsync(id));
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="userRequest">Модель пользователя</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response>
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]UserRequest userRequest)
        {
            var identity = GetIdentity(userRequest.Login, userRequest.Password);
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
        /// <param name="userRequest">Модель пользвателя</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ServiceResponse<User>> Register([FromBody]UserRequest userRequest)
        {
           return await _executeService.TryExecute(() => _userService.Create(userRequest));    
        }

        /// <summary>
        /// Изменить пароль пользователя
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response>
        [AllowAnonymous]
        [HttpPost("resertPassword")]
        public async Task<ServiceResponse<dynamic>> ResetPassword([FromBody] ResetPasswordRequest request )
        {
            return await _executeService.TryExecute(() => _userService.ResetPassword(request.Id, request.NewPasswrod));
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