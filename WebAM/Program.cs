using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infra;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;
//ici on fait l'instanciation de service pour qu'on puisse l'utiiser dans le controller
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContext, AMContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<Type>(p => typeof(GenericRepository<>));
//les builder dessus viennent avec la squelette

//intanciation des service : 
builder.Services.AddScoped<IServicePlane, ServicePlane>();
builder.Services.AddScoped<IFlightMethods, FlightMethods>();
// Add services to the container.
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
