using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using DesafioFullStackTotvs.Models;
using DesafioFullStackTotvs.Helpers;

namespace DesafioFullStackTotvs.Services
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        IEnumerable<User> GetAll();
        User GetById(long id);
        void Add(User user);
        void Update(long id, User item);
        void Delete(long id);
    }

    public class UserService : IUserService
    {
        private readonly DesafioFullStackTotvsDataContext _context;
        private readonly AppSettings _appSettings;
        
        private List<User> _users = new List<User>();        

        public UserService(IOptions<AppSettings> appSettings, DesafioFullStackTotvsDataContext context)
        {
            _context = context;
            if (_context.Users.Count () == 0) {
                _context.Users.Add (new User { Name = "Item1" });
                _context.SaveChanges ();
            }
            _appSettings = appSettings.Value;
            _users.AddRange(_context.Users.ToList());
        }

        public User Authenticate(string email, string password)
        {
            var user = _users.SingleOrDefault(x => x.Email == email && x.Password == password);
            
            if (user == null)
                return null;

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
 
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
 
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);            
            user.Token = tokenString;
            user.Password = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return _users.Select(x => {
                x.Password = "************";
                return x;
            });
        }

        public User GetById(long id){
            var item = _context.Users.Find (id);
            if (item == null) {
                return null;
            }
            return item;
        }

        public void Add(User user){
             _context.Users.Add (user);
            _context.SaveChanges ();
        }

        public void Update(long id, User user){
            var User = _context.Users.Find (id);
            if (User != null) 
            {
                User.Cpf = user.Cpf;
                User.Name = user.Name;
                User.Email = user.Email;
                User.IsAdmin = user.IsAdmin;
                User.Password = user.Password;
                User.Token = user.Token;            

                _context.Users.Update (User);
                _context.SaveChanges ();
            }
        }

        public void Delete(long id){
            var User = _context.Users.Find (id);
            if (User != null) {
                User.IsActive = false;

                _context.Users.Update (User);
                _context.SaveChanges ();
            }
        }
    }
}