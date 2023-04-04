using Microsoft.AspNetCore.Mvc;
using UserHandlerAPI.DataAccess.Repository;
using UserHandlerAPI.Models;

namespace UserHandlerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionController(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subscription>>> GetSubscriptions()
        {
            return Ok(await _subscriptionRepository.GetSubscription()); 
        }

        [HttpPost]
        public async Task<ActionResult<List<Subscription>>> CreateSubscription(Subscription subscription)
        {
            return Ok(await _subscriptionRepository.CreateSubscription(subscription));
        }

        [HttpPut]
        public async Task<ActionResult<List<Subscription>>> UpdateSubscription(Subscription subscription)
        {
            return Ok(await _subscriptionRepository.UpdateSubscription(subscription));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Subscription>>> DeleteSubscription(int id)
        {
            return Ok(await _subscriptionRepository.DeleteSubscription(id));
        }
    }
}
