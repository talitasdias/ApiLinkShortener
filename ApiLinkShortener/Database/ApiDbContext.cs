using Microsoft.EntityFrameworkCore;

namespace ApiLinkShortener.Database;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
}