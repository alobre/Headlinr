using System.Text.Json;
using System.Xml.Serialization;
using Headlinr_System2.Models;
using Headlinr_System2.Models.DTOs.Output;
using Microsoft.Extensions.Configuration;

namespace Headlinr_System2.Services.Rss;

public class RssService(HeadlinrConfigurationProvider configuration, Repository.NewsRepository repo)
{
    public async Task<IEnumerable<Headlinr_System2.Models.DTOs.Output.Item>> GetAllRssAsync()
    {
        if (string.IsNullOrWhiteSpace(configuration.RssUrl))
            throw new ArgumentException("Feed-URL darf nicht leer sein.", nameof(configuration.RssUrl));

        using var http = new HttpClient();
        await using var st = await http.GetStreamAsync(configuration.RssUrl);

        var xmlSerializer = new XmlSerializer(typeof(RssFeedInputDto));
        var feed = (RssFeedInputDto)xmlSerializer.Deserialize(st)!;
        var outputDto = feed.MapRssInputXmlToRssOutputJson();
        await repo.SaveNewsAll(outputDto);

        // **return the Items collection** (which is already an IEnumerable<Item>)
        return outputDto.Items;
    }

    public async Task<string> GetByIdAsync(string id)
    {
        return JsonSerializer.Serialize(await repo.GetByIdAsync(id));

    }
}