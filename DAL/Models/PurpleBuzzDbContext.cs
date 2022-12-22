using hometask_17.Models;
using Microsoft.EntityFrameworkCore;

namespace hometask_17.DAL.Models
{
    public class PurpleBuzzDbContext:DbContext
    {
        //public PurpleBuzzDbContext(DbContextOptions<PurpleBuzzDbContext> options):base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SS;Database=PurpleBuzzDB;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });
            modelBuilder.Entity<WorkProductCategory>()
                .HasOne(p => p.product)
                .WithMany(wpc => wpc.WorkProductCategory)
                .HasForeignKey(wi => wi.ProductId);
            modelBuilder.Entity<WorkProductCategory>()
                .HasOne(c => c.category)
                .WithMany(wpc => wpc.WorkProductCategory)
                .HasForeignKey(wi => wi.CategoryId);
        }

        public DbSet<WorkCategory>? WorkCategories { get; set; }
        public DbSet<WorkProduct>? WorkProducts { get; set; }
        public DbSet<WorkProductCategory>? WorkProductCategories { get; set; }
    }
}

