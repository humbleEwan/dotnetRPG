using Microsoft.AspNetCore.Mvc;
using RPG.Models;
using System.Net;

namespace RPG.Interfaces
{
    public interface IUserRepository {
        Task<HttpStatusCode> addUser(User newUser);
        Task<bool> authenticateUser(string username, string password);
    }
}
