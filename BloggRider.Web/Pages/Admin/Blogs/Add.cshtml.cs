using BloggRider.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BloggRider.Web.Pages.Admin.Blogs;

public class Add : PageModel
{
    [BindProperty]
    public AddBlogPost AddBlogPostRequest { set; get; }

    public void OnGet()
    {
    }

    public void OnPost() 
    {

    }
}