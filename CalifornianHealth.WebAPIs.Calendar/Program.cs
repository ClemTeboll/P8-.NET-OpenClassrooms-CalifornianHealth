using CalifornianHealth.Core.ConsultantCalendar;
using CalifornianHealth.Core.ConsultantCalendar.Contracts;
using CalifornianHealth.Infrastructure.Database;
using CalifornianHealth.Infrastructure.Database.Contexts;
using CalifornianHealth.Infrastructure.Database.Entities;
using CalifornianHealth.Infrastructure.Database.Repositories.AppointmentRepository;
using CalifornianHealth.Infrastructure.Database.Repositories.ConsultantCalendarRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var applicationConnectionString = builder.Configuration.GetConnectionString("ApplicationConnection");

builder.Services.AddCalifornianHealthContext(applicationConnectionString!);
builder.Services.AddIdentityContext(applicationConnectionString!);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy => policy.WithOrigins("https://localhost:7153")
        .AllowAnyMethod()
        .AllowAnyHeader()
    );                 
});
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityCore<Patient>()
    .AddRoles<Role>()
    .AddUserStore<PatientStore>();

builder.Services.AddScoped<IUserStore<Patient>, PatientStore>();
builder.Services.AddScoped<IRoleStore<Role>, RoleStore>();
builder.Services.AddScoped(semaphore => new Semaphore(0, 1));
builder.Services.AddTransient<IConsultantCalendarManager, ConsultantCalendarManager>();
builder.Services.AddScoped<IConsultantCalendarRepository, ConsultantCalendarRepository>();
builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();

var app = builder.Build();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()!.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<CalifornianHealthContext>();
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
