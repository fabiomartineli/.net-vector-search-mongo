using OllamaSharp;

namespace Api.Services
{
    public interface IOllamaService
    {
        OllamaApiClient Client { get; }
    }
}
