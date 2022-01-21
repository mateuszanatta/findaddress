
using System.Net.Http.Headers;
using AddressService.HttpClients.Interfaces;

#nullable enable
namespace AddressService.HttpClients
{
    public sealed class DefaultHttpClient : IHttpClients
    {
        private readonly HttpClient _client;

        public DefaultHttpClient(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
        }
        public void Add(string mediaType)
        {
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(mediaType));
        }

        public void Clear()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
        }

        public Task<Stream> GetStreamAsync(string requestUri)
        {
            return _client.GetStreamAsync(requestUri);
        }

        public Task<HttpResponseMessage> GetAsync(string? requestUri)
        {
            return _client.GetAsync(requestUri);
        }
    }
}
