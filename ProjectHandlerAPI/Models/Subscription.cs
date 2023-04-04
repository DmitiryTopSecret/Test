
using ProjectHandlerAPI.Models.Enums;
using System.Text.Json.Serialization;

namespace ProjectHandlerAPI.Models
{
    public class Subscription
    {
        //public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SubscriptionType SubscriptionType { get; set; }

        public List<Indicator> Indicators { get; set; }

        //public DateTime StartDate { get; set; }

        //public DateTime EndDate { get; set; }

    }
}
