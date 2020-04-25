using JWT.Models;
using JWT.Request;
using JWT.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWT.Controllers
{
    /// <summary>
    /// Api для работы с задачами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContextController : ControllerBase
    {
        private readonly IContextService _contextService;
        private readonly ExecuteService _executeService;

        public ContextController(IContextService contextService, ExecuteService executeService)
        {
            _contextService = contextService;
            _executeService = executeService;
        }

        /// <summary>
        /// Получить все задачи
        /// </summary>
        /// <returns>Возращает список всех задач</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response>
        [HttpGet]
        [Route("GetContexts")]
        public async Task<ServiceResponse<List<Exercises>>> GetContexts()
        {
            return await _executeService.TryExecute(() => _contextService.GetAllAsync());
        }

        /// <summary>
        /// Получить темы
        /// </summary>
        /// <returns>Возращает список тем</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpGet]
        [Route("GetTopics")]
        public async Task<ServiceResponse<List<Topics>>> GetTopics()
        {
            return await _executeService.TryExecute(() => _contextService.GetAllTopicsAsync());
        }

        /// <summary>
        /// Создать задачу
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("Create")]
        public async Task<ServiceResponse<Exercises>> CreateContexts([FromBody] Exercises exercises)
        {
            return await _executeService.TryExecute(() => _contextService.CreateAsync(exercises));
        }

        /// <summary>
        /// Редактировать задачу
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("Edit")]
        public async Task<ServiceResponse<dynamic>> EditContexts([FromBody] Exercises exercises)
        {
            return await _executeService.TryExecute(() => _contextService.EditAsync(exercises));
        }

        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("delete")]
        public async Task<ServiceResponse<dynamic>> DeleteContexts(int id)
        {
            return await _executeService.TryExecute(() => _contextService.DeleteAsync(id));
        }

        /// <summary>
        /// Проверить ответ на задачу
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("answer")]
        public async Task<ServiceResponse<bool>> GetAnswerContexts(CheackTaskRequest request)
        {
            return await _executeService.TryExecute(() => _contextService.GetAnswerAsync(request.Id, request.UserAnswer, request.UserId));
        }

        /// <summary>
        /// Получить все задачи по категории
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("allIssuesAcategory")]
        public async Task<ServiceResponse<Exercises[]>> GetAllIssuesAcategory(int id)
        {
            return await _executeService.TryExecute(() => _contextService.GetAllIssuesAcategoryAsync(id));
        }

        /// <summary>
        /// Получить задачу по id
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("getTaskById")]
        public async Task<ServiceResponse<Exercises>> GetByIdContext(int id)
        {
            return await _executeService.TryExecute(() => _contextService.GetByIdAsync(id));
        }

        /// <summary>
        /// Получить следующую задачу
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response>
        [HttpPost]
        [Route("getNextTask")]
        public async Task<ServiceResponse<Exercises>> GetNextTask(int id)
        {
            return await _executeService.TryExecute(() => _contextService.GetNextTaskAsync(id));
        }
    }
}
