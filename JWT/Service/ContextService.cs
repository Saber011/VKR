using JWT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Service
{
    /// <inheritdoc/>
    public class ContextService : IContextService
    {
        private readonly ApplicationContext db;

        public ContextService(ApplicationContext _applicationContext) =>
            db = _applicationContext;

        /// <inheritdoc/>
        public async Task<Exercises> Create(Exercises exercises)
        {
            db.Exercises.Add(exercises);
            await db.SaveChangesAsync();

            return exercises;
        }

        /// <inheritdoc/>
        public async Task<dynamic> DeleteAsync(int id)
        {
            Exercises exercisesTeam = await db.Exercises.FindAsync(id);
            db.Exercises.Remove(exercisesTeam);
            await db.SaveChangesAsync();

            var responce = new
            {
                Messege = "Задача успешно удаленна"
            };

            return responce;
        }

        /// <inheritdoc/>
        public async Task<dynamic> EditAsync(Exercises exercises)
        {
            db.Exercises.Update(exercises);
            await db.SaveChangesAsync();

            var responce = new
            {
                Messege = "Команда успешно изменена"
            };

            return responce;
        }

        /// <inheritdoc/>
        public async Task<List<Exercises>> GetAll()
        {
            return await db.Exercises.ToListAsync();
        }

        /// <inheritdoc/>
        public Task<Exercises> GetAllIssuesAcategory(int id)
        {
            //ToDo получить
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<bool> GetAnswer(int id, string userAnswer)
        {
            //Todo work
            var tasks = db.Exercises.FirstOrDefault(x => x.IdTask == id);
            return tasks.Equals(userAnswer);

        }

        /// <inheritdoc/>
        public async Task<Exercises> GetById(int id)
        {
            return await db.Exercises.FirstOrDefaultAsync(x => x.IdTask == id);
        }

        /// <inheritdoc/>
        public async Task<Exercises> GetNextTask(int id)
        {
            await db.Database.ExecuteSqlRawAsync($"ToDo create func");
            await db.SaveChangesAsync();

            throw new NotImplementedException();
        }
    }
}
