using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ProjectHandlerAPI.Models;
using ProjectHandlerAPI.Models.Enums;
using ProjectHandlerAPI.Models.Responses;
using System.Text.Json;

namespace ProjectHandlerAPI.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Project> _projectCollection;

        public MongoDbService(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _projectCollection = database.GetCollection<Project>(mongoDbSettings.Value.CollectionName);
        }

        public async Task<List<Project>> GetAsync()
        {
            return await _projectCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreateAsync(Project project)
        {
            await _projectCollection.InsertOneAsync(project);
            
            return;
        }
        
        // UNFINISHED METHOD BELOW:(
        public async Task<PopularIndicatorsResponse> GetPopularIndicators(SubscriptionType subscriptionType)
        {
            using (var httpClient = new HttpClient())
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var response = await httpClient.GetAsync("https://localhost:44312/api/Subscription");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var subscriptions = JsonSerializer.Deserialize<List<Subscription>>(content, options);

                    var filteredSubscriptions = subscriptions.Where(s => s.SubscriptionType == subscriptionType).ToList();
                }
            }

            return null;
        }
    }
}
