using CalifornianHealth.Infrastructure.Database;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var applicationConnectionString = builder.Configuration.GetConnectionString("ApplicationConnection")!;

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("configuration.json", optional: false, reloadOnChange: true);


builder.Services.AddScoped(serviceProvider => serviceProvider.GetService<CalifornianHealthContext>()!.ConsultantRepository);

builder.Services.AddControllers();
builder.Services.AddOcelot();

builder.Services.AddCalifornianHealthContext(applicationConnectionString);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseOcelot().Wait();

app.Run();