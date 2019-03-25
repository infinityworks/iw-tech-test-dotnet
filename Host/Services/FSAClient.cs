using InfinityWorks.TechTest.Model;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfinityWorks.TechTest.Services
{
    public class FSAClient : IFSAClient
    {
        private IHttpClientFactory httpClientFactory;

        public FSAClient(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<FSAAuthorityList> GetAuthorities()
        {
            return await GetFSAResource<FSAAuthorityList>("Authorities");
        }

        private async Task<T> GetFSAResource<T>(string path)
        {
            var serializer = new JsonSerializer();
            var client = httpClientFactory.CreateClient();
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
