using Microsoft.AspNetCore.Mvc;
using UserHandlerAPI.Models;

namespace UserHandlerAPI.DataAccess.Repository
{
    public interface ISubscriptionRepository
    {
        Task<ActionResult<List<Subscription>>> GetSubscription();
        Task<ActionResult<List<Subscription>>> CreateSubscription(Subscription subscription);
        Task<ActionResult<List<Subscription>>> UpdateSubscription(Subscription subscription);
        Task<ActionResult<List<Subscription>>> DeleteSubscription(int id);
    }
}
