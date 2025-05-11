using OllamaSharp;

namespace Api.Services
{
    public class OllamaService : IOllamaService
    {
        private readonly OllamaApiClient _client;

        public OllamaService(string endpoint, string model)
        {
            _client = new OllamaApiClient(endpoint, model);
        }

        public OllamaApiClient Client => _client;
    }
}
