using CalifornianHealth.Core.ConsultantCalendar;
using CalifornianHealth.Core.ConsultantCalendar.Contracts;
using CalifornianHealth.Infrastructure.Database;
using CalifornianHealth.Infrastructure.Database.Entities;
using CalifornianHealth.Infrastructure.Database.Repositories.AppointmentRepository;
using CalifornianHealth.Infrastructure.Database.Repositories.ConsultantCalendarRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Docker SQL Server Connection String
//var applicationConnectionString = "Server=tcp:192.168.1.45,8001;Database=CalifornianHealthDB;User=sa;Password=Passw0rd!;TrustServerCertificate=True";

var applicationConnectionString = builder.Configuration.GetConnectionString("ApplicationConnection");

builder.Services.AddCalifornianHealthContext(applicationConnectionString!);
builder.Services.AddIdentityContext(applicationConnectionString!);

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

builder.Services.AddIdentityCore<Patient>()
    .AddRoles<Role>()
    .AddUserStore<PatientStore>();

builder.Services.AddTransient<IConsultantCalendarManager, ConsultantCalendarManager>();
builder.Services.AddScoped<IConsultantCalendarRepository, ConsultantCalendarRepository>();
builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();

var app = builder.Build();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()!.CreateScope())
{
    var californianHealthContext = serviceScope.ServiceProvider.GetRequiredService<CalifornianHealthContext>();
    californianHealthContext.Database.Migrate();

    var identityContext = serviceScope.ServiceProvider.GetRequiredService<IdentityContext>();
    identityContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
