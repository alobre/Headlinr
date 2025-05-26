using Headlinr_System2.Services.Rss;
using System.ServiceModel;
using Headlinr_System2.Models.DTOs.Output;

namespace Headlinr_System2.Services
{
    [ServiceContract]
    public class SoapNewsFeedService(RssService rssService)
    {
        [OperationContract]
        public async Task<SoapItem[]> GetAllRssAsync() => (await rssService.GetAllRssAsync()).MapToSoap().ToArray();

        [OperationContract]
        public async Task<SoapItem> GetByIdAsync(string id) => (await rssService.GetByIdAsync(id))?.MapItemToSoap() ?? new SoapItem();
    }
}

