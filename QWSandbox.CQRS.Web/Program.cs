using System.Reflection;
using MediatR;
using QWSandbox.CQRS.Web.Infrastructure.DI;
using Serilog.Events;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    //.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message}{NewLine}{Exception}"/*, theme: AnsiConsoleTheme.Code*/)
    .WriteTo.Console()
    .WriteTo.Debug(outputTemplate: "{Timestamp:yyyy.MM.dd HH:mm:ss.fff} [{Level:u3}] {Message}{NewLine}{Exception}")
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Logging
    .ClearProviders()
    .AddSerilog();


// Add services to the container.
IServiceCollection services = builder.Services;

services.AddQWServices();


services.AddResponseCaching();
services.AddDistributedMemoryCache();

IMvcBuilder mvcBuilder = services.AddControllersWithViews();
mvcBuilder.AddRazorRuntimeCompilation();



var app = builder.Build();

//app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    
    // Don't use hsts!!!
    //app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
