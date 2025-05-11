using Microsoft.ML.Data;

namespace Api.Models
{
    public sealed record TransformEmbeddingModel
    {
        public string Text { get; init; }
        [VectorType(700)]
        public float[] TextEmbedding { get; init; }
    }
}
