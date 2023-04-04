using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserHandlerAPI.Models;

namespace UserHandlerAPI.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<User>>> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }

        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var dbUser = await _context.Users.FindAsync(id);

            _context.Users.Remove(dbUser);
            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }

        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ActionResult<List<User>>> UpdateUser(User user)
        {
            var dbUser = await _context.Users.FindAsync(user.Id);

            dbUser.Name = user.Name;
            dbUser.Email = user.Email;
            dbUser.SubscriptionId = user.SubscriptionId;

            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }
    }
}
