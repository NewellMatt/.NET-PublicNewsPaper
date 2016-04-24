using Microsoft.Data.Entity;

namespace PublicNewsPaper.Models
{
    public class PublicNewsPaperDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Story> Stories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PublicNewsPaper;integrated security = True");
        }
    }
}