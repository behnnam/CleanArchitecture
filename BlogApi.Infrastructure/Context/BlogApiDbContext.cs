using BlogApi.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace BlogApi.Infrastructure.Data
{
    public class BlogApiDbContext : DbContext
    {

        public BlogApiDbContext(DbContextOptions<BlogApiDbContext> option ):base(option) { 
        
        
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.Users)
                .HasForeignKey(p => p.UserId);
        }


    }
}
