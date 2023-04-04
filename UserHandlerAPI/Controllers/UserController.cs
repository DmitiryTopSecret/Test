using Microsoft.AspNetCore.Mvc;
using UserHandlerAPI.DataAccess.Repository;
using UserHandlerAPI.Models;

namespace UserHandlerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _userRepository.GetUsers());
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateUser(User user)
        {
            return Ok(await _userRepository.CreateUser(user));
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }
    }
}
