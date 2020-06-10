using JWT.Core;
using JWT.Interface;
using JWT.Models;
using JWT.Request;
using JWT.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JWT.Controllers
{
    /// <summary>
    /// Api для работы с пользователем
    /// </summary>
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly ExecuteService _executeService;
        private readonly IUserService _userService;

        public AccountController(IUserService userService, ExecuteService executeService)
        {
            _userService = userService;
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
        [HttpGet("GetUserById")]
        public async Task<ServiceResponse<UserModelRequest>> GetUser(int id)
        {
            return await _executeService.TryExecute(() => _userService.GetByIdAsync(id));
        }

        /// <summary>
        /// Получить пользователя по логину
        /// </summary>
        /// <param name = "login" > Логин пользвателя</param>
        /// <returns>Найденный пользватель</returns>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [Authorize]
        [HttpGet("GetUserByLogin")]
        public async Task<ServiceResponse<UserModelRequest>> GetUserByLogin(string login)
        {
            return await _executeService.TryExecute(() => _userService.GetUserByLoginAsync(login));
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
            return await _executeService.TryExecute(() => _userService.GetAllUsersAsync());
        }

        /// <summary>
        /// Удалить пользвателя
        /// </summary>
        /// <param name="id">Индефикатор пользователя</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response>
        [Authorize]
        [HttpPost("DeleteUser")]
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
        public async Task<ServiceResponse<dynamic>> Login([FromBody]UserRequest userRequest)
        {
            return await _executeService.TryExecute(() => _userService.Login(userRequest));
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
            return await _executeService.TryExecute(() => _userService.CreateAsync(userRequest));
        }

        /// <summary>
        /// Изменить пароль пользователя
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response>
        [AllowAnonymous]
        [HttpPost("resertPassword")]
        public async Task<ServiceResponse<dynamic>> ResetPassword([FromBody]ResetPasswordRequest request)
        {
            return await _executeService.TryExecute(() => _userService.ResetPasswordAsync(request.Id, request.NewPasswrod));
        }

    }
}