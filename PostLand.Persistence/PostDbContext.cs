using Microsoft.EntityFrameworkCore;
using PostLand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Persistence
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options) { }

        public DbSet<Post> posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categoryGuid = Guid.Parse(Guid.NewGuid().ToString());
            var postGuid = Guid.Parse(Guid.NewGuid().ToString());
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = categoryGuid,
                Name = "Technology"
            });
            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = postGuid,
                Title = "Intro to CQRS",
                Content = "lorem ibsum",
                ImageUrl = @"https://m.media-amazon.com/images/I/410Jw8hFN1L.jpg"
               ,
                CategoryId = categoryGuid,
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
