using Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TestDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Page> Pages { get; set; }

        public TestDbContext(DbContextOptions options) : base(options) {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Comment>().HasKey(x => x.Id);
            modelBuilder.Entity<Comment>().HasMany(x => x.Children);

            modelBuilder.Entity<Page>().HasKey(x => x.Id);
            modelBuilder.Entity<Page>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<Page>().HasMany(x => x.Comments);

            base.OnModelCreating(modelBuilder);
        }
    }
}
