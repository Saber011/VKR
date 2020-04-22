using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT.Models;
using JWT.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Controllers
{
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
        [HttpGet]
        [Route("GetContexts")]
        public async Task<ServiceResponse<List<Exercises>>> GetContexts()
        {
            return await _executeService.TryExecute(() => _contextService.GetAll());
        }

        /// <summary>
        /// Создать задачу
        /// </summary>
        [HttpPost]
        [Route("Create")]
        public async Task<ServiceResponse<Exercises>> CreateContexts([FromBody] Exercises exercises )
        {
            return await _executeService.TryExecute(() => _contextService.Create(exercises));
        }

    }
}
