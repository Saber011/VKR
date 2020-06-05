using JWT.Core;
using JWT.Interface;
using JWT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Service
{
    /// <inheritdoc/>
    public sealed class ContextService : IContextService
    {
        private readonly ApplicationContext _context;

        public ContextService(ApplicationContext _applicationContext) =>
            _context = _applicationContext;

        /// <inheritdoc/>
        public async Task<Exercises> CreateAsync(Exercises exercises)
        {
            _context.Exercises.Add(exercises);
            await _context.SaveChangesAsync();

            return exercises;
        }

        /// <inheritdoc/>
        public async Task<dynamic> DeleteAsync(int id)
        {
            Exercises exercisesTeam = await _context.Exercises.FindAsync(id);
            _context.Exercises.Remove(exercisesTeam);
            await _context.SaveChangesAsync();

            var responce = new
            {
                Messege = "Задача успешно удаленна"
            };

            return responce;
        }

        /// <inheritdoc/>
        public async Task<dynamic> EditAsync(Exercises exercises)
        {
            _context.Exercises.Update(exercises);
            await _context.SaveChangesAsync();

            var responce = new
            {
                Messege = "Задача успешно изменена"
            };

            return responce;
        }

        /// <inheritdoc/>
        public async Task<List<Exercises>> GetAllAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<List<Topics>> GetAllTopicsAsync()
        {
            return await _context.Topics.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Exercises[]> GetAllIssuesAcategoryAsync(int id)
        {
            return await _context.Exercises.Where(x => x.TopicsId == id).ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<bool> GetAnswerAsync(int idTask, string userAnswer, int userId, string language, string versionIndex)
        {

            var tasks = await _context.Exercises.FirstOrDefaultAsync(x => x.IdTask == idTask);
            var topic = await _context.Topics.FirstOrDefaultAsync(x => x.IdTopic == tasks.TopicsId);
            var result = await ApiOnlineCompilations.CallApi(userAnswer, language, versionIndex);

            if (tasks.AnswerTask.Equals(result.output))
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC CalcMp {tasks.Level} {topic.Kostil} {userId}");
            }

            return tasks.AnswerTask.Equals(result.output);
        }

        /// <inheritdoc/>
        public async Task<Exercises> GetByIdAsync(int id)
        {
            return await _context.Exercises.FirstOrDefaultAsync(x => x.IdTask == id);
        }

        /// <inheritdoc/>
        public async Task<Exercises> GetNextTaskAsync(int id)
        {
            var task = _context.Exercises.FromSqlRaw
               (
@$"DECLARE	@return_value Int
EXEC	@return_value = [dbo].[SelectionExercises5]
		@iduser = {id}
SELECT	@return_value as 'Return Value', e.* from Exercises e where e.IdTask = @return_value").ToList();

            return task[0];
        }

        /// <inheritdoc/>
        public async Task<Exercises> SkipTaskAsync(int id)
        {
            var task = _context.Exercises.FromSqlRaw
               (
@$"DECLARE	@return_value Int
EXEC	@return_value = [dbo].[SkipExercises]
		@iduser = {id}
SELECT	@return_value as 'Return Value', e.* from Exercises e where e.IdTask = @return_value").ToList();

            return task[0];
        }
    }
}
