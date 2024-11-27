using Assignment_Serilog.ExceptionHandler;
using ClassLibrary1;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddScoped<IDemoService, DemoService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandler>();
app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();
