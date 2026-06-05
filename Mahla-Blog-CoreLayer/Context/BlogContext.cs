
using Mahla_Blog_DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Mahla_Blog_DataLayer.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComment { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
