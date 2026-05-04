using Microsoft.EntityFrameworkCore;

namespace Community.Api.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<CommunityOption> CommunityOptions => Set<CommunityOption>();
}
