using BloggRider.Web.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// Get Connection String
var connectionString = builder.Configuration.GetConnectionString("SampleDbConnection");

// Initialising my DbContext inside the DI Container
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<BloggRiderDbContext>(
    option => option.UseNpgsql(connectionString));
    
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();