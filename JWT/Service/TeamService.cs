using JWT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Service
{
    /// <inheritdoc/>
    public class TeamService : ITeamService
    {
        private readonly ApplicationContext db;
        public TeamService(ApplicationContext _applicationContext) =>
            db = _applicationContext;

        /// <inheritdoc/>
        public async Task<List<Team>> AllTeams()
        {
            return  await db.Teams.ToListAsync();
        }

        private bool CanAddOrUpdateTeam(Team team)
        {
            var count = db.Teams.Where(x => x.TeamName == team.TeamName).Count();
            return count > 0  ? true : false;
        }

        /// <inheritdoc/>
        public async Task<Team> Create(Team team)
        {
            if (CanAddOrUpdateTeam(team))
            {
                throw new AppException("Необходимо указать уникальное имя конмады");
            }
            db.Teams.Add(team);
            await  db.SaveChangesAsync();

            return team;
        }

        /// <inheritdoc/>
        public async Task<dynamic> DeleteAsync(int IdTeam)
        {
            Team RemovTeam = await db.Teams.FindAsync(IdTeam);
            db.Teams.Remove(RemovTeam);
            await db.SaveChangesAsync();

            var responce = new
            {
                Messege = "Команда успешно удаленна"
            };

            return responce;
        }
    
        /// <inheritdoc/>
        public async Task<dynamic> Edit(Team team)
        {
            if (CanAddOrUpdateTeam(team))
            {
                throw new AppException("Необходимо указать уникальное имя конмады");
            }
            db.Teams.Update(team);
            await db.SaveChangesAsync();

            var responce = new
            {
                Messege = "Информация о команде успешно изменена"
            };

            return responce;
        }

        /// <inheritdoc/>
        public async Task<Team> FindTeamAsync(int IdTeam)
        {
            return await db.Teams.FindAsync(IdTeam);
        }
    }
}
