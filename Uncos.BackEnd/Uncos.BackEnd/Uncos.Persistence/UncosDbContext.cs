using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore; 
using Uncos.Application.Interfaces;
using Uncos.Domain;
using Uncos.Persistence.EntityTypeConfiguration;

namespace Uncos.Persistence
{
    public class UncosDbContext: IdentityDbContext<IdentityUser>, IUncosDbContext
    {
        public UncosDbContext(DbContextOptions<UncosDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>() 
                .HasIndex(u => u.UserName)
                .IsUnique();
            modelBuilder.Entity<IdentityUser>()
                .HasIndex(u => u.Email)
                .IsUnique(); 
            modelBuilder.ApplyConfiguration(new NewsTagConfiguration()); 



            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Like> Likes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NewsTag> NewsTags { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
