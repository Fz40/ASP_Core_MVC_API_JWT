
using Microsoft.EntityFrameworkCore;
using JWTApi.Models;

#nullable disable

namespace JWTApi.Data
{
    public partial class NorthwindContext : DbContext
    {


        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
