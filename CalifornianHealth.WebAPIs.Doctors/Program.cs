using CalifornianHealth.Core.Consultant;
using CalifornianHealth.Core.Consultant.Contracts;
using CalifornianHealth.Infrastructure.Database;
using CalifornianHealth.Infrastructure.Database.Contexts;
using CalifornianHealth.Infrastructure.Database.Entities;
using CalifornianHealth.Infrastructure.Database.Repositories.ConsultantRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Docker SQL Server Connection String
//var applicationConnectionString = "Server=tcp:192.168.1.45,8001;Database=CalifornianHealthDB;User=sa;Password=Passw0rd!;TrustServerCertificate=True";

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

builder.Services.AddTransient<IConsultantManager, ConsultantManager>();
builder.Services.AddScoped<IConsultantRepository, ConsultantRepository>();

var app = builder.Build();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()!.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<CalifornianHealthContext>();
    //context.Database.Migrate();
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
