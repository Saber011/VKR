using JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Service
{
    public class ContextService : IContextService
    {
        private readonly ApplicationContext db;
        public ContextService(ApplicationContext _applicationContext) =>
            db = _applicationContext;

        public Tasks Create(Tasks tasks)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tasks> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Tasks> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tasks> GetNextTask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
