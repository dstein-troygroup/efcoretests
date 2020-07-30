using Microsoft.EntityFrameworkCore;

namespace EFCoreTests.Models
{
    public class EFCoreTestsDatabaseContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Writer> Writers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\sqlexpress;Database=EFCoreTests;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
