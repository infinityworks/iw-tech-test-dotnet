using InfinityWorks.TechTest.Model;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfinityWorks.TechTest.Services
{
    public class FsaClient : IFsaClient
    {
        private IHttpClientFactory _httpClientFactory;

        public FsaClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<FsaAuthorityList> GetAuthorities()
        {
            return await GetFsaResource<FsaAuthorityList>("Authorities");
        }

        private async Task<T> GetFsaResource<T>(string path)
        {
            var serializer = new JsonSerializer();
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("x-api-version", "2");

            var stream = await client.GetStreamAsync($"http://api.ratings.food.gov.uk/{path}");

            using (var sr = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(sr))
            {
                return serializer.Deserialize<T>(jsonTextReader);
            }
        }
    }
}
