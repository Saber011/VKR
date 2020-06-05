using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT.Core;
using JWT.Interface;
using JWT.Interfaces;
using JWT.Models;
using JWT.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewServiceController : ControllerBase
    {
        private readonly ExecuteService _executeService;
        private readonly INewContextService _newService;

        public NewServiceController(INewContextService newContextService, ExecuteService executeService)
        {
            _newService = newContextService;
            _executeService = executeService;
        }

        /// <summary>
        /// Добавить тест
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response>
        [HttpPost("AddTest")]
        public async Task<ServiceResponse<aTests>> AddTest(aTests test, int number)
        {
            return await _executeService.TryExecute(() => _newService.AddTest(test,number));
        }

        /// <summary>
        /// Начать изучение
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response>
        [HttpPost("Start")]
        public async Task<ServiceResponse<aHierarchySubjectsUsers>> StartListen(aHierarchySubjectsUsers aHierarchySubjectsUsers)
        {
            return await _executeService.TryExecute(() => _newService.StartListen(aHierarchySubjectsUsers));
        }

        /// <summary>
        /// Добавить новый предмет
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response>
        [HttpPost("AddSubject")]
        public async Task<ServiceResponse<aSubjects>> AddSubject(aSubjects subjects)
        {
            return await _executeService.TryExecute(() => _newService.AddSubject(subjects));
        }

        /// <summary>
        /// Добавить новую задачу
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response>
        [HttpPost("AddTask")]
        public async Task<ServiceResponse<aExercises>> AddTask(aExercises tests)
        {
            return await _executeService.TryExecute(() => _newService.AddExercises(tests));
        }

        /// <summary>
        /// Проверить решение задачи
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response>
        [HttpPost("Answer")]
        public async Task<ServiceResponse<bool>> Anser(int idUser, int idTask, string answer, int parent)
        {
            return await _executeService.TryExecute(() => _newService.AnswerTask(idUser,idTask, answer, parent));
        }

        /// <summary>
        /// Получить все предметы
        /// </summary>
        /// <returns>Возращает список всех команд</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpGet]
        [Route("GetSubjects")]
        public async Task<ServiceResponse<aSubjects[]>> GetSubjects()
        {
            return await _executeService.TryExecute(() => _newService.GetSubjects());
        }

        /// <summary>
        /// Получить предмет по  id
        /// </summary>
        /// <param name="id">Индификатор команды</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpGet]
        [Route("GetSubject")]
        public async Task<ServiceResponse<aSubjects>> GetSubject(int id)
        {
            return await _executeService.TryExecute(() => _newService.GetSubject(id));
        }

        /// <summary>
        /// Удалить предмет
        /// </summary>
        /// <param name="Id">Индификатор команды</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("DeleteSubject")]
        public async Task<ServiceResponse<aSubjects>> DeleteSubject(int Id)
        {
            return await _executeService.TryExecute(() => _newService.DeleteSubject(Id));
        }

        /// <summary>
        /// Изменить информацию о предмете
        /// </summary>
        /// <param name="subjects"></param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("EditSubject")]
        public async Task<ServiceResponse<aSubjects>> EditSubject([FromBody]aSubjects subjects)
        {
            return await _executeService.TryExecute(() => _newService.EditSubject(subjects));
        }

        /// <summary>
        /// Получить все тесты
        /// </summary>
        /// <returns>Возращает список всех команд</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpGet]
        [Route("GetTests")]
        public async Task<ServiceResponse<aTests[]>> GetTests()
        {
            return await _executeService.TryExecute(() => _newService.GetTests());
        }

        /// <summary>
        /// Получить тест по  id
        /// </summary>
        /// <param name="id">Индификатор команды</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpGet]
        [Route("GetTest")]
        public async Task<ServiceResponse<aTests>> GetTest(int id)
        {
            return await _executeService.TryExecute(() => _newService.GetTest(id));
        }

        /// <summary>
        /// Удалить тест
        /// </summary>
        /// <param name="Id">Индификатор команды</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("DeleteTest")]
        public async Task<ServiceResponse<aTests>> DeleteTest(int Id)
        {
            return await _executeService.TryExecute(() => _newService.DeleteTest(Id));
        }

        /// <summary>
        /// Изменить информацию о тесте
        /// </summary>
        /// <param name="test"></param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("EditTest")]
        public async Task<ServiceResponse<aTests>> EditTest([FromBody]aTests test)
        {
            return await _executeService.TryExecute(() => _newService.EditTest(test));
        }

        /// <summary>
        /// Получить все задачи
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpGet]
        [Route("GetExercisess")]
        public async Task<ServiceResponse<aExercises[]>> GetExercisess()
        {
            return await _executeService.TryExecute(() => _newService.GetExercisess());
        }

        /// <summary>
        /// Получить задачу по  id
        /// </summary>
        /// <param name="id">Индификатор команды</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpGet]
        [Route("GetExercises")]
        public async Task<ServiceResponse<aExercises>> GetExercises(int id)
        {
            return await _executeService.TryExecute(() => _newService.GetExercises(id));
        }

        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <param name="Id">Индификатор команды</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("DeleteExercises")]
        public async Task<ServiceResponse<aExercises>> DeletDeleteExerciseseTest(int Id)
        {
            return await _executeService.TryExecute(() => _newService.DeleteExercises(Id));
        }

        /// <summary>
        /// Изменить информацию о задаче
        /// </summary>
        /// <param name="exercises"></param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("EditExercises")]
        public async Task<ServiceResponse<aExercises>> EditExercises([FromBody]aExercises exercises)
        {
            return await _executeService.TryExecute(() => _newService.EditExercises(exercises));
        }

        /// <summary>
        /// Иерархия
        /// </summary>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("GetHierarchySubjectsUsers")]
        public async Task<ServiceResponse<aHierarchySubjectsUsers[]>> GetHierarchySubjectsUsers()
        {
            return await _executeService.TryExecute(() => _newService.GetHierarchySubjectsUsers());
        }

        /// <summary>
        /// Иерархия пользователя
        /// </summary>
        /// <param name="idUser"></param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("GetHierarchySubjectsUsers1")]
        public async Task<ServiceResponse<aHierarchySubjectsUsers[]>> GetHierarchySubjectsUsers1(int idUser)
        {
            return await _executeService.TryExecute(() => _newService.GetHierarchySubjectsUsers(idUser));
        }
    }
}