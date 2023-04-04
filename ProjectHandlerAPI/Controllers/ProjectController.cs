using Microsoft.AspNetCore.Mvc;
using ProjectHandlerAPI.Models;
using ProjectHandlerAPI.Models.Enums;
using ProjectHandlerAPI.Services;

namespace ProjectHandlerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly MongoDbService _mongoDbService;
        
        public ProjectController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        [HttpGet]
        public async Task<List<Project>> Get()
        {
            return await _mongoDbService.GetAsync();
        }

        [HttpGet]
        [Route("api/popularIndicators/{subscriptionType}")]
        public async Task GetPopularIndicators(SubscriptionType subscriptionType)
        {
            await _mongoDbService.GetPopularIndicators(subscriptionType);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Project project)
        {
            _mongoDbService.CreateAsync(project);

            return CreatedAtAction(nameof(Get), new { id = project.Id }, project);
        }
    }
}
