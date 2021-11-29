using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

/*builder.Services.AddDbContext<SecretSantaContext>(options =>
    options.UseSqlServer("Data Source = SQL5080.site4now.net; Initial Catalog = db_a7d1a0_test; User Id = db_a7d1a0_test_admin; Password = TestPass1!"));
*/
builder.Services.AddDbContext<SecretSantaContext>(options =>
    options.UseSqlServer("Server=localhost;Database=master;User Id=test;password=test;Trusted_Connection=True;"));
builder.Services.AddControllersWithViews();

var app = builder.Build();
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
