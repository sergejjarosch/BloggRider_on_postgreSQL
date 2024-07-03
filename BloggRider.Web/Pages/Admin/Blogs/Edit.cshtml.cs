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

    public IActionResult OnPostEdit()
    {
        var existingBlogPost = _bloggRiderDbContext.BlogPosts.Find(BlogPost.Id);

        if (existingBlogPost != null)
        {
            existingBlogPost.Heading = BlogPost.Heading;
            existingBlogPost.PageTitle = BlogPost.PageTitle;
            existingBlogPost.Content = BlogPost.Content;
            existingBlogPost.ShortDescription = BlogPost.ShortDescription;
            existingBlogPost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
            existingBlogPost.UrlHandle = BlogPost.UrlHandle;
            existingBlogPost.PublishedDate = BlogPost.PublishedDate;
            existingBlogPost.Author = BlogPost.Author;
            existingBlogPost.Visible = BlogPost.Visible;
        }

        _bloggRiderDbContext.SaveChanges();
        return RedirectToPage("/Admin/Blogs/List");
    }

    public IActionResult OnPostDelete()
    {
      var existingBlog = _bloggRiderDbContext.BlogPosts.Find(BlogPost.Id);

      if (existingBlog != null)
      {
          _bloggRiderDbContext.BlogPosts.Remove(existingBlog);
          _bloggRiderDbContext.SaveChanges();

          return RedirectToPage("/Admin/Blogs/List");
      }

      return Page(); // ToDo Message on screen - this BlogPost was not found
    }
}