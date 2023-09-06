using Carwash;
using Carwash.Entities;
using Carwash.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddScoped<IMainService,MainService>();
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(op =>
    {
        op.SerializerSettings.ContractResolver = new DefaultContractResolver();
    });
builder.Services.AddKendo();
builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer("Server=.;Database=Carwash;Integrated Security=True;"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
