using CalifornianHealth.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var applicationConnectionString = builder.Configuration.GetConnectionString("ApplicationConnection")!;

builder.Services.AddScoped(serviceProvider => serviceProvider.GetService<CalifornianHealthContext>()!);

builder.Services.AddCalifornianHealthContext(applicationConnectionString);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
