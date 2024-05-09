using MongoDB.Bson;

namespace Receptsida.Models
{
    public class Recipe
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Ingred { get; set; }
    }
}
