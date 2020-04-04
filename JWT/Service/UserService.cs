using JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace JWT.Service
{

    /// <inheritdoc/>
    public class UserService : IUserService
    {
        private ApplicationContext _context;
        private static readonly Encoding encoding = Encoding.UTF8;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public User Create(User user, string password)
        {  // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Users.Any(x => x.Login == user.Login))
                throw new AppException("Username \"" + user.Login + "\" is already taken");

            user.Password = SecurePasswordHasher.PasHas(password);
            _context.Users.Add(user);
            _context.SaveChanges();
            var users = _context.Users.FirstOrDefault(x => x.Login == user.Login);
            _context.UserRoles.Add(new UserRoles { UserId = users.Id});
            _context.SaveChanges();
            return user;
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }


    }
}
