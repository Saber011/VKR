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

        public ContextController(IContextService contextService) =>
            _contextService = contextService;

        /// <summary>
        /// Получить все задачи
        /// </summary>
        /// <returns>Возращает список всех задач</returns>
        [HttpGet]
        [Route("GetContexts")]
        public List<Exercises> GetContexts()
        {
            return _contextService.GetAll();
        }

        /// <summary>
        /// Создать задачу
        /// </summary>
        [HttpPost]
        [Route("Create")]
        public Task CreateContexts([FromBody] Exercises exercises )
        {
            return _contextService.Create(exercises);
        }


    }
}
