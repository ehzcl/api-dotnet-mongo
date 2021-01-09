using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace mongo_dotnet.Models
{
    public class Infectado
    {
        public Infectado(DateTime dtNascimento, string sex, double lat, double lon) {
            this.DataNascimento = dtNascimento;
            this.Sexo = sex;
            this.Localizacao = new GeoJson2DGeographicCoordinates(lon, lat);
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}