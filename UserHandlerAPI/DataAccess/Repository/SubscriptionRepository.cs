using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserHandlerAPI.Models;

namespace UserHandlerAPI.DataAccess.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly UserContext _context;
        public SubscriptionRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Subscription>>> CreateSubscription(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();

            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<ActionResult<List<Subscription>>> DeleteSubscription(int id)
        {
            var dbSubscription = await _context.Subscriptions.FindAsync(id);

            _context.Subscriptions.Remove(dbSubscription);
            await _context.SaveChangesAsync();

            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<ActionResult<List<Subscription>>> GetSubscription()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<ActionResult<List<Subscription>>> UpdateSubscription(Subscription subscription)
        {
            var dbSubscriptions = await _context.Subscriptions.FindAsync(subscription.Id);

            dbSubscriptions.SubscriptionType = subscription.SubscriptionType;
            dbSubscriptions.StartDate = subscription.StartDate;
            dbSubscriptions.EndDate = subscription.EndDate;

            await _context.SaveChangesAsync();

            return await _context.Subscriptions.ToListAsync();
        }
    }
}
