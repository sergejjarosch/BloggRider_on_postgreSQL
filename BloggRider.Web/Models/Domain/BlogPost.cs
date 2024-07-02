namespace BloggRider.Web.Domain;

public class BlogPost
{
    public Guid Id { get; set; }
    public string Heading { get; set; }
    public string PageTitle { get; set; }
    public string Content { get; set; }
    public string ShortDescription { get; set; }
    public string FeaturedImageUrl { get; set; }
    public string UrlHandle { get; set; }
    
    private DateTime _publishedDate;

    public DateTime PublishedDate
    {
        get => _publishedDate;
        set => _publishedDate = value.ToUniversalTime();
    }
    public string Author { get; set; }
    public bool Visible { get; set; }
    
}