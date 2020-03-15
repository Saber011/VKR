using JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Service
{
   public interface IUserService
    {
        User GetById(int id);
        User Create(User user, string password);
        Task DeleteAsync(int id);
    }
}
