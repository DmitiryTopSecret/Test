using MongoDB.Bson;

namespace ProjectHandlerAPI.Models
{
    public class Project
    {
        public ObjectId Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public Chart[] Charts { get; set; }
    }
}
