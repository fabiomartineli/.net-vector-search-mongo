using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using MongoDB.Driver;

namespace Infra.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private const string COLLECTION_NAME = "movie-vector-search";
        private readonly IMongoCollection<Movie> _collection;

        public MovieRepository(IDatabaseContext context)
        {
            _collection = context.Database.GetCollection<Movie>(COLLECTION_NAME);
        }

        public async Task AddAsync(Movie entity)
        {
            await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions()
            {
                IsUpsert = true
            });
        }

        public async Task<IEnumerable<Movie>> SearchAsync(float[] destinationEmbedding)
        {
            return await _collection
                .Aggregate()
                .VectorSearch(x => x.DescriptionEmbedding, 
                                    queryVector: destinationEmbedding, 
                                    limit: 5,
                                    options: new VectorSearchOptions<Movie>()
                                    {
                                        IndexName = "vector-search-index",
                                        Exact = false,
                                        NumberOfCandidates = 10
                                    })
                .ToListAsync();
        }
    }
}
