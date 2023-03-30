using RPG.Data;
using RPG.Interfaces;
using RPG.Models;
using System.Net;

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
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }


        private readonly DataContext _context;
    }
}
