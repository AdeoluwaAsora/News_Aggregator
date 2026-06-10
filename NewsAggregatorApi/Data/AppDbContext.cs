using Microsoft.EntityFrameworkCore;
using NewsAggregatorApi.Models;

namespace NewsAggregatorApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<NewsItem> NewsItems { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }
    }
}