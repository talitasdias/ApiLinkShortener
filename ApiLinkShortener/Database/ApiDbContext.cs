using Microsoft.EntityFrameworkCore;

namespace ApiLinkShortener.Database;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<UrlMappings> UrlMappings { get; set; }
}

public class UrlMappings
{
    public int Id { get; set; }
    public string? ShortenUrl { get; set; }
    public string? LongUrl { get; set; }
}