using JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using JWT.Request;
using JWT.ViewModel;

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
        public async Task<User> Create(UserRequest user)
        {  // validation
            if (string.IsNullOrWhiteSpace(user.Password))
                throw new AppException("Password is required");

            if (_context.Users.Any(x => x.Login == user.Login))
                throw new AppException("Username \"" + user.Login + "\" is already taken");

            user.Password = SecurePasswordHasher.PasHas(user.Password);
            var userModel = new User() { Login = user.Login, Password = user.Password };
            _context.Users.Add(userModel);
            _context.SaveChanges();
            var users = _context.Users.FirstOrDefault(x => x.Login == user.Login);
            // ToDo create triger
            _context.UserRoles.Add(new UserRoles { UserId = users.Id});
            _context.Level1.Add(new Level1 {});
            _context.Level2.Add(new Level2 {});
            _context.Level3.Add(new Level3 {});
            await _context.SaveChangesAsync();

            return userModel;
        }

        /// <inheritdoc/>
        public async Task<dynamic> DeleteAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC DeleteUser {id};");
            await _context.SaveChangesAsync();
            var responce = new
            {
                Messege = "Успешно удаленно"
            };

            return responce;
        }

        /// <inheritdoc/>
        public async Task<UserModelRequest> GetById(int id)
        {
            return (UserModelRequest) await _context.Users.FindAsync(id);
        }

        /// <inheritdoc/>
        public async Task<UserModelRequest[]> GetAllUsers()
        {
            var users = await _context.Users.ToArrayAsync();
            var result = new UserModelRequest[users.Length];
            for (int i = 0; i < users.Length; i++)
            {
                result[i] = (UserModelRequest)users[i];
            }
            return result;
        }

        /// <inheritdoc/>
        public async Task<dynamic> ResetPassword(int id, string newPassword)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new AppException("Не существует пользователя с таким индификатором");
            }
            user.Password = SecurePasswordHasher.PasHas(newPassword);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            var responce = new
            {
                Messege = "Пароль успешно изменен"
            };

            return responce;
        }
    }
}
