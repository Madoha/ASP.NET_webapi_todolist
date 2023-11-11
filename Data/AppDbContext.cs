using Microsoft.EntityFrameworkCore;
using ToDoList_web_api.Models;

namespace ToDoList_web_api.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoList>()
                .HasMany(r => r.Reviews)
                .WithOne(t => t.ToDoList)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reviewer>()
                .HasMany(r => r.Reviews)
                .WithOne(r => r.Reviewer)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
