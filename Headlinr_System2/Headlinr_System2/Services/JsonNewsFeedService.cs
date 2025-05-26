using Headlinr_System2.Services.Rss;

namespace Headlinr_System2.Services;

public class JsonNewsFeedService(RssService rssService)
{
    public async Task<IEnumerable<Models.DTOs.Output.Item>> GetAllRssAsync()
        => await rssService.GetAllRssAsync();

    public async Task<Models.DTOs.Output.Item?> GetByIdAsync(string id)
    => await rssService.GetByIdAsync(id);
}
