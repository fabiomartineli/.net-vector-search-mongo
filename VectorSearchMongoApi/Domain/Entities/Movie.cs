namespace Domain.Entities
{
    public class Movie
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; }
        public string Description { get; init; }
        public float[] DescriptionEmbedding { get; set; }

        public void SetEmbedding(float[] value) => DescriptionEmbedding = value;
    }
}
