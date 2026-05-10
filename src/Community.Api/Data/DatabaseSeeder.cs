using Microsoft.EntityFrameworkCore;

namespace Community.Api.Data;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(IServiceProvider services, CancellationToken ct = default)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DataContext>();

        // Create DB (if needed) + apply migrations (if any exist)
        var pending = await context.Database.GetPendingMigrationsAsync(ct);
        if (pending.Any())
            await context.Database.MigrateAsync(ct);
        else
            await context.Database.EnsureCreatedAsync(ct);

        var seed = new[]
        {
            new CommunityOption
            {
                CommunityName = "Slack Community",
                Url = "https://slack.com/",
                IconUrl = "/icons/slackicon.png"
            },
            new CommunityOption
            {
                CommunityName = "Discord Helpline",
                Url = "https://discord.gg",
                IconUrl = "/icons/discordicon.png"
            }
        };

        var existingNames = await context.CommunityOptions
            .AsNoTracking()
            .Select(x => x.CommunityName)
            .ToListAsync(ct);

        var existing = existingNames.ToHashSet(StringComparer.OrdinalIgnoreCase);

        var toAdd = seed.Where(x => !existing.Contains(x.CommunityName)).ToList();
        if (toAdd.Count == 0)
            return;

        context.CommunityOptions.AddRange(toAdd);
        await context.SaveChangesAsync(ct);
    }
}