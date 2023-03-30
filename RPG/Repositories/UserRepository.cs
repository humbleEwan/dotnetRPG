using RPG.Data;
using RPG.Interfaces;
using RPG.Models;
using System.Net;
using System.Text.RegularExpressions;

namespace RPG.Repositories
{
    public class UserRepository : IUserRepository {
        public UserRepository(DataContext context) {
            _context = context;
        }

        public ICollection<User> getUsers() {
            return _context.Users.ToList();
        }

        public async Task<HttpStatusCode> addUser(User newUser) {
            if (Regex.IsMatch(newUser.username, "([a-zA-Z0-9]{3,19})") && Regex.IsMatch(newUser.password, "([a-zA-Z0-9]{7,19})")) {
                User registeringUser = newUser;
                registeringUser.password = BCrypt.Net.BCrypt.HashPassword(newUser.password, workFactor: 13);
                _context.Users.Add(registeringUser);
                await _context.SaveChangesAsync();
                return HttpStatusCode.Created;
            } else {
                return HttpStatusCode.NotAcceptable;
            }
        }


        private readonly DataContext _context;
    }
}
