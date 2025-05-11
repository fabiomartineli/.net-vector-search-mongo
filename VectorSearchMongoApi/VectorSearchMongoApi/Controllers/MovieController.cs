using Api.Models;
using Api.Services;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using System.Net;

namespace Api.Controllers
{
    [ApiController]
    [Route("movies")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class MovieController : ControllerBase
    {
        private static readonly MLContext _mlContext = new();
        private readonly IEmbeddingGeneratorService _embeddingGenerator;

        public MovieController(IEmbeddingGeneratorService embeddingGenerator)
        {
            _embeddingGenerator = embeddingGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Movie movie, [FromServices] IMovieRepository repository)
        {
            //var transformModel = new TransformEmbeddingModel { Text = movie.Description };
            //var pipeline = _mlContext.Transforms.Text.FeaturizeText(nameof(TransformEmbeddingModel.TextEmbedding), nameof(TransformEmbeddingModel.Text));
            //var dataView = _mlContext.Data.LoadFromEnumerable([transformModel]);
            //var model = pipeline.Fit(dataView);
            //var transformedData = model.Transform(dataView);
            //var embeddings = _mlContext.Data.CreateEnumerable<TransformEmbeddingModel>(transformedData, reuseRowObject: false).FirstOrDefault();

            var emdedding = await _embeddingGenerator.ExecuteAsync(movie.Description, default);
            movie.SetEmbedding(emdedding);
            await repository.AddAsync(movie);

            return StatusCode(HttpStatusCode.Created.GetHashCode());
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromBody] TransformEmbeddingModel query, [FromServices] IMovieRepository repository)
        {
            //var pipeline = _mlContext.Transforms.Text.FeaturizeText(nameof(TransformEmbeddingModel.TextEmbedding), nameof(TransformEmbeddingModel.Text));
            //var dataView = _mlContext.Data.LoadFromEnumerable([query]);
            //var model = pipeline.Fit(dataView);
            //var transformedData = model.Transform(dataView);
            //var embeddings = _mlContext.Data.CreateEnumerable<TransformEmbeddingModel>(transformedData, reuseRowObject: false).FirstOrDefault();

            var emdedding = await _embeddingGenerator.ExecuteAsync(query.Text, default);
            var result = await repository.SearchAsync(emdedding);
            return Ok(result.Select(x => new { x.Name, x.Description }));
        }
    }
}
