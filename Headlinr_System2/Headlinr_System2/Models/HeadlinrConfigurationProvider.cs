namespace Headlinr_System2.Models
{
    public class HeadlinrConfigurationProvider(IConfiguration configuration)
    {
        public string RssUrl { get => configuration["RssUrl"] ?? string.Empty; }

        public string MongoDbConnectionString { get => configuration["ConnectionStrings:MongoDb"] ?? string.Empty;}
    }
}
