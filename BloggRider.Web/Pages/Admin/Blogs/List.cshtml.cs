using BloggRider.Web.Data;
using BloggRider.Web.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BloggRider.Web.Pages.Admin.Blogs;

public class ListModel : PageModel
{
    private readonly BloggRiderDbContext bloggRiderDbContext;

    public List<BlogPost> BlogPosts { get; set; }
    public ListModel(BloggRiderDbContext bloggRiderDbContext)
    {
        this.bloggRiderDbContext = bloggRiderDbContext;
    }
    public void OnGet()
    {
        BlogPosts = bloggRiderDbContext.BlogPosts.ToList();
    }
}