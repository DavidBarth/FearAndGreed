using FearAndGreed.Models;
using Microsoft.EntityFrameworkCore;

namespace FearAndGreed.Data
{
    public class FearAndGreedContext : DbContext
    {
        public FearAndGreedContext(DbContextOptions<FearAndGreedContext> options) : base(options)
        {
        }

        public DbSet<FearAndGreedModel> FearAndGreeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FearAndGreedModel>().ToTable("FearAndGreed");
        }
    }
}
