using JWT.Models;
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
        public List<Team> AllTeams()
        {
            return db.Teams.ToList();
        }

        private bool CanAddOrUpdateTeam(Team team)
        {
            var count = db.Teams.Where(x => x.TeamName == team.TeamName).Count();
            return count > 0  ? true : false;
        }

        /// <inheritdoc/>
        public async Task Create(Team team)
        {
            if (CanAddOrUpdateTeam(team))
            {
                throw new AppException("Необходимо указать уникальное имя конмады");
            }
            db.Teams.Add(team);
            await  db.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int IdTeam)
        {
            Team RemovTeam = await db.Teams.FindAsync(IdTeam);
            if (RemovTeam == null)
            {
                throw new AppException("Не возможно удалить эту команду");
            }
            db.Teams.Remove(RemovTeam);
            await db.SaveChangesAsync();
        }
    
        /// <inheritdoc/>
        public async Task Edit(Team team)
        {
            if (CanAddOrUpdateTeam(team))
            {
                throw new AppException("Необходимо указать уникальное имя конмады");
            }
            db.Teams.Update(team);
            await db.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<Team> FindTeamAsync(int IdTeam)
        {
            var team = await db.Teams.FindAsync(IdTeam);
            if (team == null)
            {
                new AppException("Команда не найдена");
            }
           return  team;
        }
    }
}
