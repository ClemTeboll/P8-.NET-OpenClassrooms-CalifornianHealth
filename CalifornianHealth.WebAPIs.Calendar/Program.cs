using CalifornianHealth.Core.ConsultantCalendar;
using CalifornianHealth.Core.ConsultantCalendar.Contracts;
using CalifornianHealth.Infrastructure.Database;
using CalifornianHealth.Infrastructure.Database.Repositories.ConsultantCalendarRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Docker SQL Server Connection String
//var applicationConnectionString = "Server=tcp:192.168.1.45,8001;Database=CalifornianHealthDB;User=sa;Password=Passw0rd!;TrustServerCertificate=True";

var applicationConnectionString = "";

builder.Services.AddCalifornianHealthContext(applicationConnectionString);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
           policy.WithOrigins("https://localhost:7153")
                                 .AllowAnyMethod()
                                 .AllowAnyHeader());
                     
});
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IConsultantCalendarManager, ConsultantCalendarManager>();
builder.Services.AddScoped<IConsultantCalendarRepository, ConsultantCalendarRepository>();



var app = builder.Build();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<CalifornianHealthContext>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();


app.Run();
