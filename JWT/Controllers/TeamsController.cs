﻿using JWT.Core;
using JWT.Interface;
using JWT.Models;
using JWT.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWT.Controllers
{

    /// <summary>
    /// Api для работы с командами
    /// </summary>
    [Route("api/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        /// <summary>
        /// Сервис для работы с командами
        /// </summary>
        private readonly ITeamService _teamsService;
        private readonly ExecuteService _executeService;

        /// <summary>
        /// Констуртор
        /// </summary>
        /// <param name="teamService"></param>
        /// <param name="executeService"></param>
        public TeamsController(ITeamService teamService, ExecuteService executeService)
        {
            _executeService = executeService;
            _teamsService = teamService;
        }

        /// <summary>
        /// Получить все команды
        /// </summary>
        /// <returns>Возращает список всех команд</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpGet]
        [Route("GetTeams")]
        public async Task<ServiceResponse<List<Team>>> GetTeams()
        {
            return await _executeService.TryExecute(() => _teamsService.GetAllTeamsAsync());
        }

        /// <summary>
        /// Получить команду по ее id
        /// </summary>
        /// <param name="id">Индификатор команды</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpGet]
        [Route("GetTeam")]
        public async Task<ServiceResponse<Team>> GetTeam(int id)
        {
            return await _executeService.TryExecute(() => _teamsService.FindTeamAsync(id));
        }

        /// <summary>
        /// Удалить команду
        /// </summary>
        /// <param name="Id">Индификатор команды</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("DeleteTeams")]
        public async Task<ServiceResponse<dynamic>> DeleteTeams(int Id)
        {
            return await _executeService.TryExecute(() => _teamsService.DeleteAsync(Id));
        }

        /// <summary>
        /// Добавить команду
        /// </summary>
        /// <param name="team">Индификатор команды</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("AddTeams")]
        public async Task<ServiceResponse<Team>> AddTeams([FromBody]Team team)
        {
            return await _executeService.TryExecute(() => _teamsService.CreateAsync(team));
        }

        /// <summary>
        /// Изменить информацию о команде
        /// </summary>
        /// <param name="team">Индификатор команды</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code="500">Непредвиденная ошибка сервера.</response> 
        [HttpPost]
        [Route("EditTeams")]
        public async Task<ServiceResponse<dynamic>> EditTeams([FromBody]Team team)
        {
            return await _executeService.TryExecute(() => _teamsService.EditAsync(team));
        }
    }
}
