using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        Task<IEnumerable<User>> GetAll2();
        User GetById(int id);
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        { 
            new User { id = 1, firstname = "Admin", lastname = "User", username = "admin", password = "admin", role = Role.Admin },
            new User { id = 2, firstname = "Normal", lastname = "User", username = "user", password = "user", role = Role.User } 
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.username == username && x.password == password);
            // return null if user not found
            if (user == null)
                return null;
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.id.ToString()),
                    new Claim(ClaimTypes.Role, user.role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);
            return user.WithoutPassword();
        }

        public IEnumerable<User> GetAll()
        {
            return _users.WithoutPasswords();
        }


        public async Task<IEnumerable<User>> GetAll2()
        {
            return await Task.Run(() => _users.WithoutPasswords());
        }

        public User GetById(int id) 
        {
            var user = _users.FirstOrDefault(x => x.id == id);
            return user.WithoutPassword();
        }
    }
}