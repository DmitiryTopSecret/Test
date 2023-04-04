using MongoDB.Bson.Serialization.Attributes;

namespace ProjectHandlerAPI.Models
{
    public class Chart
    {
        public string Symbol { get; set; }

        public string Timeframe { get; set; }

        public Indicator[] Indicators { get; set; }
    }
}
