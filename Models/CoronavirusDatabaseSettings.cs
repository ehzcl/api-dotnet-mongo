namespace mongo_dotnet.Models
{
    public class CoronavirusDatabaseSettings : ICoronavirusDatabaseSettings
    {
        public string InfectadoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICoronavirusDatabaseSettings
    {
        string InfectadoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}