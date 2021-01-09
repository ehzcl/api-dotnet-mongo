using mongo_dotnet.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace mongo_dotnet.Services
{
    public class InfectadosService
    {
        private readonly IMongoCollection<Infectado> _infectados;

        public InfectadosService (IDatabaseSettings settings) {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);

            _infectados = db.GetCollection<Infectado>(settings.InfectadosCollectionName);
        }

        public List<Infectado> Get() => _infectados.Find(infectado => true).ToList();

        public Infectado Get(string id) => _infectados.Find<Infectado>(infectado => infectado.Id == id).FirstOrDefault();

        public Infectado Create(Infectado infectado)
        {
            _infectados.InsertOne(infectado);
            return infectado;
        }

        public void Update(string id, Infectado infectadoIn) => _infectados.ReplaceOne(infectado => infectado.Id == id, infectadoIn);

        public void Remove(Infectado infectadoIn) => _infectados.DeleteOne(infectado => infectado.Id == infectadoIn.Id);

        public void Remove(string id) => _infectados.DeleteOne(infectado => infectado.Id == id);
    }
}