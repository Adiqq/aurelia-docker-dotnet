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
            modelBuilder.Entity<Comment>().HasOne(x => x.Page).WithMany(x => x.Comments);

            modelBuilder.Entity<Page>().HasKey(x => x.Id);
            modelBuilder.Entity<Page>().HasAlternateKey(x => x.Name);

            base.OnModelCreating(modelBuilder);
        }
    }
}
