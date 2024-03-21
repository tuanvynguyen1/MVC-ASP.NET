using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using lan2.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserContext") ?? throw new InvalidOperationException("Connection string 'UserContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "user",
    pattern: "{controller=Users}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "job",
    pattern: "{controller=Jobs}/{action=Index}/{id?}");
app.Run();
