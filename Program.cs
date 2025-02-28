using BlazorBiblioteca.Components;
using BlazorBiblioteca.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Configurar servicios
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // Necesario para Blazor Server

builder.Services.AddDbContext<LibroDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient();
builder.Services.AddControllers();

// 🔹 Construir la aplicación
var app = builder.Build();

// 🔹 Configurar Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// 🔹 Configuración adicional para anti-forgery (necesario en Blazor Server)
app.UseAntiforgery();

app.MapBlazorHub();
app.MapRazorComponents<App>();
app.MapControllers();

app.Run();
