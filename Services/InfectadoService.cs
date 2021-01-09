using mongo_dotnet.Models;
using MongoDB.Driver;
using System.Linq;
using System.Collections.Generic;

namespace mongo_dotnet.Services
{
    public class InfectadoService
    {
        private readonly IMongoCollection<Infectado> _infectados;

        public InfectadoService(ICoronavirusDatabaseSettings settings) {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _infectados = database.GetCollection<Infectado>(settings.InfectadoCollectionName);
        }

        public List<Infectado> Get() => 
            _infectados.Find(infectado => true).ToList();

        public Infectado Get(string id) =>
            _infectados.Find<Infectado>(i => i.Id == id).FirstOrDefault();

        public Infectado Create(Infectado i) {
            _infectados.InsertOne(i);
            return i;
        }

        public void Update(string id, Infectado i) =>
            _infectados.ReplaceOne(inf => inf.Id == id, i);

        public void Remove(Infectado i) =>
            _infectados.DeleteOne(inf => inf.Id == i.Id );

        public void Remove(string id) =>
            _infectados.DeleteOne(i => i.Id == id);
    }
}