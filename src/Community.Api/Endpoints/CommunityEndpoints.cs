using Community.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Community.Api.Endpoints;

public static class CommunityEndpoints
{
    public static void MapCommunityEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/communities")
            .WithTags("Communities")
            .WithDescription("Handles endpoints for community options");

        group.MapGet("/all", Get);
    }

    private static async Task<IResult> Get(DataContext context, CancellationToken ct = default)
    {
        var communities = await context.CommunityOptions.AsNoTracking().ToListAsync(ct);
        return Results.Ok(communities);
    }
}
