namespace NGE.TechTest.Services;

using NGE.TechTest.Model;
using System.Text.Json;

public class FsaClient : IFsaClient
{
    private readonly IHttpClientFactory _httpClientFactory;

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
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Add("x-api-version", "2");

        var stream = await client.GetStreamAsync($"https://api.ratings.food.gov.uk/{path}");
        return await JsonSerializer.DeserializeAsync<T>(stream)
            ?? throw new InvalidOperationException("Deserialization returned null.");
    }
}