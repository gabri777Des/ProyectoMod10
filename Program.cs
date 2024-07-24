using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProyectoMod10.Models;

var builder = WebApplication.CreateBuilder(args);

//configuracion de la inyeccion de dependecias del Contexto de Datos (es el acceso de la bd)
builder.Services.AddDbContext<ContextoDeDatos>(opciones =>
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));


// Add services to the container.
builder.Services.AddControllersWithViews();

//Configuracion de la autenticacion mediante Cookies
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Usuario/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

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

/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Actividad}/{action=Index}/{id?}");
});*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
