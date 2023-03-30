using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<HttpStatusCode> addUser(User newUser) {
            if (Regex.IsMatch(newUser.username, "([a-zA-Z0-9]{3,19})") && Regex.IsMatch(newUser.password, "([a-zA-Z0-9]{7,19})")) {
                User registeringUser = newUser;
                registeringUser.password = BCrypt.Net.BCrypt.HashPassword(newUser.password, workFactor: 13);
                try {
                    _context.Users.Add(registeringUser);
                    await _context.SaveChangesAsync();
                } catch(Exception ex) {
                    return ex.GetType().Name == "DbUpdateException" ? HttpStatusCode.NotModified : HttpStatusCode.Conflict;
                }
                return HttpStatusCode.OK;
            } else {
                return HttpStatusCode.NotAcceptable;
            }
        }

        public async Task<bool> authenticateUser(string username, string password) {
            var asd = await _context.Users.Where(e => e.username == username).FirstOrDefaultAsync();
            return asd != null ? BCrypt.Net.BCrypt.Verify(password, asd.password) : false;
        }

        private readonly DataContext _context;
    }
}
