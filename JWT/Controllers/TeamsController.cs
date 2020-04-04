using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JWT.Models;
using JWT.Service;

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

      /// <summary>
      /// Констуртор
      /// </summary>
      /// <param name="teamService"></param>
      public TeamsController(ITeamService teamService) =>
            _teamsService = teamService;

        /// <summary>
        /// Получить все команды
        /// </summary>
        /// <returns>Возращает список всех команд</returns>
        [HttpGet]
        [Route("GetTeams")]
        public List<Team> GetTeams()
        {
            return _teamsService.AllTeams();
        }

        /// <summary>
        /// Получить команду по ее id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Возращает искомую команду</returns>
        [HttpGet]
        [Route("GetTeam")]
        public async Task<Team> GetTeam(int id)
        {
            return await _teamsService.FindTeamAsync(id);
        }

        /// <summary>
        /// Удалить команду
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteTeams")]
        public async Task DeleteTeams(int Id)
        {
          await  _teamsService.DeleteAsync(Id);
        }

        /// <summary>
        /// Добавить команду
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddTeams")]
        public async Task AddTeams([FromBody]Team team)
        {
            await _teamsService.Create(team);
        }


        /// <summary>
        /// Изменить информацию о команде
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("EditTeams")]
        public async Task EditTeams([FromBody]Team team)
        {
            await _teamsService.Edit(team);
        }
    }
}
