namespace Community.Api.Endpoints;

public static class CommunityEndpoints
{
    public static void MapCommunityEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/communities")
            .WithTags("Communities")
            .WithDescription("Handles endpoints for community options");

        //group.MapPost("/examples", Post);
        group.MapGet("/all", Get);
        //group.MapPut("/examples", Put);
        //group.MapDelete("/examples", Delete);
    }

    //private static IResult Post() => Results.Created();

    private static IResult Get() => Results.Ok();

    //private static IResult Put() => Results.Ok();

    //private static IResult Delete() => Results.NoContent();
}
