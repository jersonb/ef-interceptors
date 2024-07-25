using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EfInterceptors.Models;

namespace EfInterceptors.Data
{
    public class EfInterceptorsContext : DbContext
    {
        public EfInterceptorsContext (DbContextOptions<EfInterceptorsContext> options)
            : base(options)
        {
        }

        public DbSet<EfInterceptors.Models.Product> Product { get; set; } = default!;
    }
}
