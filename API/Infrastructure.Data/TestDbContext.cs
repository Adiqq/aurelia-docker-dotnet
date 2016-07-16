using Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) : base(options) {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TestData>().HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
