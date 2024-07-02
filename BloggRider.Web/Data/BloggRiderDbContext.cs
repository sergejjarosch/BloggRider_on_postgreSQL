using BloggRider.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace BloggRider.Web.Data;



public class BloggRiderDbContext: DbContext
{

    public BloggRiderDbContext(DbContextOptions<BloggRiderDbContext> options) : base(options)
    {
    }
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<Tag> Tags { get; set; }
}