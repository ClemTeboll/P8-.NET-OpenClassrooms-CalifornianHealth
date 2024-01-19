//using CalifornianHealth.Core.ConsultantCalendar;
//using CalifornianHealth.Core.ConsultantCalendar.Contracts;
//using CalifornianHealth.Infrastructure.Database;
//using CalifornianHealth.Infrastructure.Database.Repositories.ConsultantCalendarRepository;

//var builder = WebApplication.CreateBuilder(args);
////var applicationConnectionString = builder.Configuration.GetConnectionString("ApplicationConnection")!;

////var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
////var dbName = Environment.GetEnvironmentVariable("DB_NAME");
////var dbPassword = Environment.GetEnvironmentVariable("SA_PASSWORD");
//var applicationConnectionString = "Server=tcp:192.168.1.45,8001;Database=CalifornianHealthDB;User=sa;Password=Passw0rd!;TrustServerCertificate=True";
//builder.Services.AddCalifornianHealthContext(applicationConnectionString);

//builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddTransient<IConsultantCalendarManager, ConsultantCalendarManager>();
//builder.Services.AddScoped<IConsultantCalendarRepository, ConsultantCalendarRepository>();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using CalifornianHealth.Core.ConsultantCalendar;
using CalifornianHealth.Core.ConsultantCalendar.Contracts;
using CalifornianHealth.Infrastructure.Database;
using CalifornianHealth.Infrastructure.Database.Repositories.ConsultantCalendarRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
//var dbName = Environment.GetEnvironmentVariable("DB_NAME");
//var dbPassword = Environment.GetEnvironmentVariable("SA_PASSWORD");
var applicationConnectionString = "Server=tcp:192.168.1.45,8001;Database=CalifornianHealthDB;User=sa;Password=Passw0rd!;TrustServerCertificate=True";

builder.Services.AddCalifornianHealthContext(applicationConnectionString);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
