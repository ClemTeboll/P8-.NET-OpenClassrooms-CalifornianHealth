using CalifornianHealth.Core.Consultant;
using CalifornianHealth.Core.Consultant.Contracts;
using CalifornianHealth.Infrastructure.Database;
using CalifornianHealth.Infrastructure.Database.Repositories.ConsultantRepository;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var applicationConnectionString = builder.Configuration.GetConnectionString("ApplicationConnection")!;

builder.Services.AddCalifornianHealthContext(applicationConnectionString);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped(serviceProvider => serviceProvider.GetService<CalifornianHealthContext>()!.ConsultantRepository);
builder.Services.AddTransient<IConsultantManager, ConsultantManager>();
builder.Services.AddScoped<IConsultantRepository, ConsultantRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
