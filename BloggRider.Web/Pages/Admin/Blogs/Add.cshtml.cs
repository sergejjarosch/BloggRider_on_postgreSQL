using BloggRider.Web.Data;
using BloggRider.Web.Domain;
using BloggRider.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BloggRider.Web.Pages.Admin.Blogs;

public class Add : PageModel
{
    private readonly BloggRiderDbContext bloggRiderDbContext;
    
    [BindProperty]
    public AddBlogPost AddBlogPostRequest { set; get; }

    public Add(BloggRiderDbContext bloggRiderDbContext)
    {
        this.bloggRiderDbContext = bloggRiderDbContext;
    }
    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        var blogPost = new BlogPost()
        {
            Heading = AddBlogPostRequest.Heading,
            PageTitle = AddBlogPostRequest.PageTitle,
            Content =  AddBlogPostRequest.Content,
            ShortDescription = AddBlogPostRequest.ShortDescription,
            FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
            UrlHandle = AddBlogPostRequest.UrlHandle,
            PublishedDate = AddBlogPostRequest.PublishedDate,
            Author = AddBlogPostRequest.Author,
            Visible = AddBlogPostRequest.Visible
        };
        bloggRiderDbContext.BlogPosts.Add(blogPost);
        bloggRiderDbContext.SaveChanges();

        return RedirectToPage("Admin/Blog/List");
    }
}