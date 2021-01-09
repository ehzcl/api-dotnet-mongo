namespace mongo_dotnet.Models
{
    public class InfectadosDatabaseSettings : IDatabaseSettings
    {
        public string InfectadosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings {
        string InfectadosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}