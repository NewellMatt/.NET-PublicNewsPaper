using Microsoft.Data.Entity;

namespace PublicNewsPaper.Models
{
    public class PublicNewsPaperDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Story> Stories { get; set; }
    }
}