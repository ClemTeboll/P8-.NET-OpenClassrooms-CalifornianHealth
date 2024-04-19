using CalifornianHealth.Core.Consultant;
using CalifornianHealth.Core.Consultant.Contracts;
using CalifornianHealth.Infrastructure.Database;
using CalifornianHealth.Infrastructure.Database.Contexts;
using CalifornianHealth.Infrastructure.Database.Entities;
using CalifornianHealth.Infrastructure.Database.Repositories.ConsultantRepository;
using CalifornianHealth.WebAPIs.Doctors.Endpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var applicationConnectionString = builder.Configuration.GetConnectionString("ApplicationConnection");

builder.Services.AddCalifornianHealthContext(applicationConnectionString!);
builder.Services.AddIdentityContext(applicationConnectionString!);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5013")
            .AllowAnyMethod()
            .AllowAnyHeader();
        policy.WithOrigins("https://localhost:7153")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CalifornianHealth.WebAPIs.Doctors", Version = "v1" });
});

builder.Services.AddDbContext<CalifornianHealthContext>(options =>
    options.UseSqlServer(applicationConnectionString));

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(applicationConnectionString));

builder.Services.AddIdentityCore<Patient>()
    .AddRoles<Role>()
    .AddUserStore<PatientStore>();

builder.Services.AddScoped<IUserStore<Patient>, PatientStore>();
builder.Services.AddScoped<IRoleStore<Role>, RoleStore>();

builder.Services.AddScoped<IConsultantManager, ConsultantManager>();
builder.Services.AddScoped<IConsultantRepository, ConsultantRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapConsultantEndpoints();

app.Run();