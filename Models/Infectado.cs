using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongo_dotnet.Models
{
    public class Infectado
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public Double Latitude { get; set; }

        public Double Longitude { get; set; }

    }
}