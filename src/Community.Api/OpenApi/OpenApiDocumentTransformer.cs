using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace Community.Api.OpenApi;

public sealed class OpenApiDocumentTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
    {
        document.Components ??= new OpenApiComponents();

        document.Info.Description = """
        ## Introduction

        The Community API provides a set of endpoints for managing communities within the system. 
        It allows clients to retrieve a list of available communities as well as perform standard 
        CRUD operations (Create, Read, Update, Delete).

        With this API, you can:
        - Fetch all communities or specific community details
        - Create new communities
        - Update existing communities
        - Delete communities

        This enables flexible management and integration of community-based features in your application.
        """;

        return Task.CompletedTask;
    }
}
