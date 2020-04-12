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
        public async Task Create(Exercises Exercises)
        {
            db.Exercises.Add(Exercises);
            await db.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            Exercises exercisesTeam = await db.Exercises.FindAsync(id);
            if (exercisesTeam == null)
            {
                throw new AppException("Не возможно удалить эту задачу");
            }
            db.Exercises.Remove(exercisesTeam);
            await db.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task EditAsync(Exercises exercises)
        {
            db.Exercises.Update(exercises);
            await db.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public List<Exercises> GetAll()
        {
            return db.Exercises.ToList();
        }

        /// <inheritdoc/>
        public Task<Exercises> GetAllIssuesAcategory(int id)
        {
            //ToDo получить
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool GetAnswer(int id, string userAnswer)
        {
            var tasks = db.Exercises.FirstOrDefault(x => x.IdTask == id);
            return tasks.Equals(userAnswer);

        }

        /// <inheritdoc/>
        public Exercises GetById(int id)
        {
            return db.Exercises.FirstOrDefault(x => x.IdTask == id);
        }

        /// <inheritdoc/>
        public async Task<Exercises> GetNextTask(int id)
        {
          await  db.Database.ExecuteSqlCommandAsync(@"
ToDo create func");
            db.SaveChanges();

            throw new NotImplementedException();
        }
    }
}
