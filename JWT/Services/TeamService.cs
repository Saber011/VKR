using JWT.Exceptions;
using JWT.Interface;
using JWT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace JWT.Service
{
    /// <inheritdoc/>
    public sealed class TeamService : ITeamService
    {
        private readonly ApplicationContext _context;
        public TeamService(ApplicationContext _applicationContext) =>
            _context = _applicationContext;

        /// <inheritdoc/>
        public async Task<List<Team>> GetAllTeamsAsync()
        {
            return await _context.Teams.OrderBy(x => x.TeamRating).ToListAsync();
        }

        private bool CanAddOrUpdateTeam(Team team)
        {
            var count = _context.Teams.Where(x => x.TeamName == team.TeamName).Count();

            return count > 0;
        }

        /// <inheritdoc/>
        public async Task<Team> CreateAsync(Team team)
        {
            if (CanAddOrUpdateTeam(team))
            {
                throw new AppException("Необходимо указать уникальное имя конмады");
            }

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return team;
        }

        /// <inheritdoc/>
        public async Task<dynamic> DeleteAsync(int IdTeam)
        {
            Team RemovTeam = await _context.Teams.FindAsync(IdTeam);
            _context.Teams.Remove(RemovTeam);
            await _context.SaveChangesAsync();

            var responce = new
            {
                Messege = "Команда успешно удаленна"
            };

            return responce;
        }

        /// <inheritdoc/>
        public async Task<dynamic> EditAsync(Team team)
        {
            if (CanAddOrUpdateTeam(team))
            {
                throw new AppException("Необходимо указать уникальное имя конмады");
            }
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();

            var responce = new
            {
                Messege = "Информация о команде успешно изменена"
            };

            return responce;
        }

        /// <inheritdoc/>
        public async Task<Team> FindTeamAsync(int IdTeam)
        {
            return await _context.Teams.FindAsync(IdTeam);
        }

        /// <inheritdoc/>
        public async Task<dynamic> AddUserToTeam(int IdTeam, int idUser)
        {
            _context.UserTeams.Add(new UserTeams { UserId = idUser, TeamIdTeam = IdTeam });
            await _context.SaveChangesAsync();

            return new
            {
                Messeges = "Пользователь успешно добавлен в команду"
            };
        }


        /// <inheritdoc/>
        public async Task<UsersTeams[]> GetUsersTeams(int idUser)
        {
            return await _context.UsersTeams.Where(x => x.Id == idUser).ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<UsersTeams[]> GetTeamUser(int idTeam)
        {
            return await _context.UsersTeams.Where(x => x.IdTeam == idTeam).ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<dynamic> RemovUserToTeam(int IdTeam, int idUser)
        {
            _context.UserTeams.Remove(new UserTeams { UserId = idUser, TeamIdTeam = IdTeam });
            await _context.SaveChangesAsync();

            return new
            {
                Messeges = "Пользователь успешно удален из команды"
            };
        }
    }
}
