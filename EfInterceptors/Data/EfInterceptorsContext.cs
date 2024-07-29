using EfInterceptors.Models;
using Microsoft.EntityFrameworkCore;

namespace EfInterceptors.Data;

public class EfInterceptorsContext(
    DbContextOptions<EfInterceptorsContext> options,
    ILogger<EfInterceptorsContext> logger)
    : DbContext(options)
{
    public DbSet<Product> Product { get; set; } = default!;

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Pré: SaveChangesAsync");

        var result = base.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Pós: SaveChangesAsync");

        return result;
    }
}