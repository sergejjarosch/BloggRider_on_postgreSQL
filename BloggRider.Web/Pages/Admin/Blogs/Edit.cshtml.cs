using BloggRider.Web.Data;
using BloggRider.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BloggRider.Web.Pages.Admin.Blogs;

public class Edit : PageModel
{
    private readonly BloggRiderDbContext _bloggRiderDbContext;
    
    [BindProperty]
    public BlogPost BlogPost { get; set; }
    public Edit(BloggRiderDbContext bloggRiderDbContext)
    {
        _bloggRiderDbContext = bloggRiderDbContext;
    }
    public void OnGet(Guid id)
    {
        BlogPost = _bloggRiderDbContext.BlogPosts.Find(id);
    }
}