using Microsoft.EntityFrameworkCore;
using UserHandlerAPI.Models;

namespace UserHandlerAPI.DataAccess
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
