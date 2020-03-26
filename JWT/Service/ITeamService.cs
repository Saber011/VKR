﻿using JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Service
{

    /// <summary>
    /// Сервис для работы с командами
    /// </summary>
   public interface ITeamService
    {

        /// <summary>
        /// Получить все команды
        /// </summary>
        /// <returns></returns>
        List<Team> AllTeams();

        /// <summary>
        /// Поиск команды по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Team> FindTeamAsync(int id);

        /// <summary>
        /// Создание команды
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        Task Create(Team team);

        /// <summary>
        /// Удаление команды
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Редактирование данных команды
        /// </summary>
        /// <returns></returns>
        Task Edit(Team team);
    }
}