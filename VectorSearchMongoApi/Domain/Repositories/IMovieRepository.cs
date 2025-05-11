using Domain.Entities;

namespace Domain.Repositories
{
    public interface IMovieRepository
    {
        Task AddAsync(Movie entity);
        Task<IEnumerable<Movie>> SearchAsync(float[] destinationEmbedding);
    }
}
