using SoftrayNewsAPI.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftrayNewsAPI.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> InsertUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);
        Task<User> Authenticate(AuthModel modeld);
    }
}
