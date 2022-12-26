using hometask_17.Models;
using Microsoft.EntityFrameworkCore;

namespace hometask_17.DAL.Models
{
    public class PurpleBuzzDbContext : DbContext
    {
        public PurpleBuzzDbContext(DbContextOptions<PurpleBuzzDbContext> options):base(options) { }

        public DbSet<WorkCategory>? WorkCategories { get; set; }
        public DbSet<WorkProduct>? WorkProducts { get; set; }
        public DbSet<WorkImage>? WorkImages { get; set; }
    }
}

