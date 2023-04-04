using System.Text.Json.Serialization;

namespace ProjectHandlerAPI.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionType
    {
        Free,
        Trial,
        Super
    }
}
