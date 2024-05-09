using MongoDB.Bson;

namespace Receptsida.Models
{
    public class Ingredients
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Taste { get; set; }
    }
}
