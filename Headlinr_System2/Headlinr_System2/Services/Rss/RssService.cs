using System.Text.Json;
using System.Xml.Serialization;
using Headlinr_System2.Models;

namespace Headlinr_System2.Services.Rss;

public class RssService(HeadlinrConfigurationProvider configuration, Repository.NewsRepository repo)
{
    public async Task<string> GetAllRssAsync()
    {
        if (string.IsNullOrWhiteSpace(configuration.RssUrl))
            throw new ArgumentException("Feed-URL darf nicht leer sein.", nameof(configuration.RssUrl));

        using var http = new HttpClient();
        await using var stream = await http.GetStreamAsync(configuration.RssUrl);

        var reader = new StreamReader(stream);
        var xmlSerializer = new XmlSerializer(typeof(RssFeedInputDto));
        var feed = (RssFeedInputDto)xmlSerializer.Deserialize(reader)!;
        var outputDto = feed.MapRssInputXmlToRssOutputJson();

        await repo.SaveNewsAll(outputDto);

        return JsonSerializer.Serialize(outputDto);
    }

    public async Task<string> GetByIdAsync(string id)
    {
        return JsonSerializer.Serialize(await repo.GetByIdAsync(id));

    }
}