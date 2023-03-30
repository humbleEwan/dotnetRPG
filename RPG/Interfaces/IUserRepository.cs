using RPG.Models;
using System.Net;

namespace RPG.Interfaces
{
    public interface IUserRepository {
        ICollection<User> getUsers();
        Task<HttpStatusCode> addUser(User newUser);
    }
}
