using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

//using InsurancePremiumCalculator.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog for date-wise log files in Logs folder
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(
        path: "Logs/log-.txt", // Will create Logs folder and log files per day
        rollingInterval: RollingInterval.Day,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}"
    )
    .CreateLogger();

builder.Host.UseSerilog(); // Use Serilog for logging

// Add MVC services
builder.Services.AddControllersWithViews();

// Register dependencies
builder.Services.AddScoped<IInsuranceCalculator, InsuranceCalculator>();
builder.Services.AddScoped<IOccupationRepository, OccupationRepositoryMock>();

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Premium}/{action=Index}/{id?}");

app.Run();
