using Headlinr_System2.Models;
using Headlinr_System2.Models.DTOs.Output;
using MongoDB.Driver;

namespace Headlinr_System2.Repository;

public class NewsRepository
{
    private readonly HeadlinrConfigurationProvider _provider;
    private readonly MongoClient _client;
    readonly IMongoCollection<DbWrapperItem> _newsCollection;
    public NewsRepository(HeadlinrConfigurationProvider provider)
    {
        _provider = provider;
        _client = new(provider.MongoDbConnectionString);
        _newsCollection = _client.GetDatabase("News").GetCollection<DbWrapperItem>("News");
    }
    public async Task SaveNewsAll(RssFeedOutputDto feed)
    {
        var allDbNews = (await _newsCollection.Find(Builders<DbWrapperItem>.Filter.Empty)
            .ToListAsync());

        var uniqueItems = feed.Items
            .Where(item => allDbNews.All(dbItem => dbItem.Id != item.Guid.Value))
            .ToList();

        if (uniqueItems.Count.Equals(0))
            return;

        await _newsCollection.InsertManyAsync(uniqueItems.Select(item => new DbWrapperItem
        {
            Id = item.Guid.Value,
            Item = item
        }));
    }

    public async Task<Models.DTOs.Output.Item?> GetByIdAsync(string id)
    {
        return (await _newsCollection.Find(news => news.Id.Equals(id)).FirstOrDefaultAsync()).Item;
    }
}