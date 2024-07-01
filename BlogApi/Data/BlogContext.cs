using BlogApi.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace BlogApi.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }
    }
}
