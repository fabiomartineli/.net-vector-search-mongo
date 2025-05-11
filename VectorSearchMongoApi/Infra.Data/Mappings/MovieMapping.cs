using Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Infra.Data.Mappings
{
    public static class MovieMapping
    {
        public static void Map()
        {
            BsonClassMap.RegisterClassMap<Movie>(x =>
            {
                x.AutoMap();
                x.MapMember(m => m.Id).SetElementName("_id");
                x.MapMember(m => m.Name).SetElementName("name").SetDefaultValue(string.Empty);
                x.MapMember(m => m.Description).SetElementName("description").SetDefaultValue(string.Empty);
                x.MapMember(m => m.DescriptionEmbedding).SetElementName("description_embedding").SetDefaultValue(Array.Empty<float>());
            });
        }
    }
}
