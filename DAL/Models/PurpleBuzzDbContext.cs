using hometask_17.Models;
using Microsoft.EntityFrameworkCore;

namespace hometask_17.DAL.Models
{
    public class PurpleBuzzDbContext : DbContext
    {
        public PurpleBuzzDbContext(DbContextOptions<PurpleBuzzDbContext> options):base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=SS;Database=PurpleBuzzDB;Integrated Security=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}
        public DbSet<WorkCategory>? WorkCategories { get; set; }
        public DbSet<WorkProduct>? WorkProducts { get; set; }
    }
}

