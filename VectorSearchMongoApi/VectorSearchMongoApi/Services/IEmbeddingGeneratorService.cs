namespace Api.Services
{
    public interface IEmbeddingGeneratorService
    {
        Task<float[]> ExecuteAsync(string value, CancellationToken cancellationToken);
    }
}
