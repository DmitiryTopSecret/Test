using Microsoft.AspNetCore.Mvc;
using UserHandlerAPI.Models;

namespace UserHandlerAPI.DataAccess.Repository
{
    public interface IUserRepository
    {
        Task<ActionResult<List<User>>> GetUsers();
        Task<ActionResult<List<User>>> CreateUser(User user);
        Task<ActionResult<List<User>>> UpdateUser(User user);
        Task<ActionResult<List<User>>> DeleteUser(int id);
    }
}
