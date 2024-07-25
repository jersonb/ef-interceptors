using EfInterceptors.Models;
using Microsoft.EntityFrameworkCore;

namespace EfInterceptors.Data;

public class EfInterceptorsContext(DbContextOptions<EfInterceptorsContext> options)
    : DbContext(options)
{
    public DbSet<Product> Product { get; set; } = default!;
}