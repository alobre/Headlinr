using System.Text.Json;
using System.Xml.Serialization;
using Headlinr_System2.Models;
using Headlinr_System2.Models.DTOs.Output;
using Microsoft.Extensions.Configuration;

namespace Headlinr_System2.Services.Rss;

public class RssService(HeadlinrConfigurationProvider configuration, Repository.NewsRepository repo)
{
    public async Task<IEnumerable<Models.DTOs.Output.Item>> GetAllRssAsync()
    {
        if (string.IsNullOrWhiteSpace(configuration.RssUrl))
            throw new ArgumentException("Feed-URL darf nicht leer sein.", nameof(configuration.RssUrl));

        using var http = new HttpClient();
        await using var networkStream = await http.GetStreamAsync(configuration.RssUrl);

        var xmlSerializer = new XmlSerializer(typeof(RssFeedInputDto));
        var feed = (RssFeedInputDto)xmlSerializer.Deserialize(networkStream)!;
        var outputDto = feed.MapRssInputXmlToRssOutputJson();
        await repo.SaveNewsAll(outputDto);

        return outputDto.Items;
    }

    public async Task<Models.DTOs.Output.Item?> GetByIdAsync(string id)
    {
        return await repo.GetByIdAsync(id);

    }
}