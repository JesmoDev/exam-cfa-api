using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CFA_API.Entities;

namespace CFA_API.Services
{
    public class CFAContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Product> Products { get; set; }

        public CFAContext(DbContextOptions<CFAContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
