using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Models;
using MVCProject.Data;
using MVCProject.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVCProjectContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MVCProjectContext") ?? throw new InvalidOperationException("Connection string 'MVCProjectContext' not found.")));

//UseSqlServer
//UseNpgsql
// Add services to the container.
builder.Services.AddControllersWithViews();

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


try
{
    if (Convert.ToBoolean(config["Seed"]))
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            SeedData.Initialize(services);
        }
    }

}
catch { 

}

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
