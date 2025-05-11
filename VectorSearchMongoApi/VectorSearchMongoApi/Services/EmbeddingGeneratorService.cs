using OllamaSharp;

namespace Api.Services
{
    public class EmbeddingGeneratorService : IEmbeddingGeneratorService
    {
        private readonly IOllamaService _service;

        public EmbeddingGeneratorService(IOllamaService service)
        {
            _service = service;
        }

        public async Task<float[]> ExecuteAsync(string value, CancellationToken cancellationToken)
        {
            var response = await _service.Client.EmbedAsync(value);
            return response.Embeddings.First();
        }
    }
}
