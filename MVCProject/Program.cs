using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCProject.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVCProjectContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MVCProjectContext") ?? throw new InvalidOperationException("Connection string 'MVCProjectContext' not found.")));

//UseSqlServer
//UseNpgsql
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
