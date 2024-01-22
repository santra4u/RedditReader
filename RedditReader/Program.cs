using Microsoft.AspNetCore.Hosting;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();



app.UseRouting();


app.UseAuthorization();

Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("c:/logs/myapp.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

app.MapRazorPages();

app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    
    );

app.Run();
