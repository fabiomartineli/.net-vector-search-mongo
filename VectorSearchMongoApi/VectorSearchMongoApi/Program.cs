using Api.Services;
using Domain.Repositories;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.Extensions.AI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IDatabaseContext, DatabaseContext>(_ => new(builder.Configuration.GetValue<string>("MongoDb:ConnectionString"), builder.Configuration.GetValue<string>("MongoDb:Database")));
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddSingleton<IOllamaService, OllamaService>(_ => new(builder.Configuration.GetValue<string>("Ollama:Endpoint"), builder.Configuration.GetValue<string>("Ollama:Model")));
builder.Services.AddSingleton<IEmbeddingGeneratorService, EmbeddingGeneratorService>();

var app = builder.Build();
app.MapOpenApi();
app.UseAuthorization();
app.MapControllers();
app.Run();
