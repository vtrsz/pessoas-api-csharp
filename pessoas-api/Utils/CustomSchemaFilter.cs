using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace pessoas_api.Utils
{
    public class CustomSchemaFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (swaggerDoc.Components.Schemas.TryGetValue("PersonCreationDto", out OpenApiSchema personCreationSchema))
            {
                personCreationSchema.Properties["birthDate"].Format = "date";
            }

            if (swaggerDoc.Components.Schemas.TryGetValue("PersonResponseDto", out OpenApiSchema personResponseSchema))
            {
                personResponseSchema.Properties["birthDate"].Format = "date";
            }
        }
    }
}