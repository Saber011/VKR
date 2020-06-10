using JWT.Exceptions;
using JWT.Interface;
using JWT.Models;
using JWT.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Service
{

    /// <inheritdoc/>
    public sealed class UserService : IUserService
    {
        private ApplicationContext _context;
        private static readonly Encoding encoding = Encoding.UTF8;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<User> CreateAsync(UserRequest user)
        {
            // validation
            if (string.IsNullOrWhiteSpace(user.Password))
                throw new AppException("Password is required");

            if (_context.Users.Any(x => x.Login == user.Login))
                throw new AppException("Username \"" + user.Login + "\" is already taken");

            user.Password = SecurePasswordHasher.PasHas(user.Password);
            var userModel = new User() { Login = user.Login, Password = user.Password };
            _context.Users.Add(userModel);
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
        public async Task<UserModelRequest> GetByIdAsync(int id)
        {
            return (UserModelRequest)await _context.Users.FindAsync(id);
        }

        /// <inheritdoc/>
        public async Task<UserModelRequest[]> GetAllUsersAsync()
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
        public async Task<dynamic> ResetPasswordAsync(int id, string newPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=> x.Id == id);
            if (user == null)
            {
                throw new AppException("Не существует пользователя с таким идетификатором");
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

        /// <inheritdoc/>
        public async Task<dynamic> Login(UserRequest request)
        {
            var identity = GetIdentity(request.Login, request.Password);
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name,
                id =  _context.Users.FirstOrDefault(x => x.Login == request.Login).Id,
        };

            return response;
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            User person = _context.Users.FirstOrDefault(x => x.Login == username);

            if (person == null)
            {
                throw new AppException("Invalid username or password");
            }

            /* Fetch the stored value */
            string savedPasswordHash = person.Password;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    throw new AppException("Invalid username or password");

            if (person != null)
            {
                var firstUserRoles = _context.UserRoles.FirstOrDefault(x => x.UserId == person.Id);
                var roles = _context.Roles.FirstOrDefault(x => x.IdRole == firstUserRoles.RoleIdRole);

                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, roles.NameRole)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }

        public async Task<UserModelRequest> GetUserByLoginAsync(string login)
        {
            return (UserModelRequest)await _context.Users.FirstOrDefaultAsync(x=>x.Login == login);
        }
    }
}
