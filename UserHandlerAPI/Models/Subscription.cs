using System.Text.Json.Serialization;
using UserHandlerAPI.Models.Enums;

namespace UserHandlerAPI.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SubscriptionType SubscriptionType { get; set; } 

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
