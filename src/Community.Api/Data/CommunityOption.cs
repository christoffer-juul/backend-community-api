using System.ComponentModel.DataAnnotations;

namespace Community.Api.Data;

public class CommunityOption
{
    [Key]
    public int Id { get; set; }

    public string CommunityName { get; set; } = null!;

    public string? Url { get; set; }

    public string? IconUrl { get; set; }
}