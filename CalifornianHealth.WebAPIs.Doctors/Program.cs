using CalifornianHealth.Core.Consultant;
using CalifornianHealth.Core.Consultant.Contracts;
using CalifornianHealth.Infrastructure.Database;
using CalifornianHealth.Infrastructure.Database.Repositories.ConsultantRepository;

var builder = WebApplication.CreateBuilder(args);

//var applicationConnectionString = builder.Configuration.GetConnectionString("ApplicationConnection")!;
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("SA_PASSWORD");
var applicationConnectionString = $"Data Source={dbHost};Initial Catalogue={dbName}; User Id=sa; Password={dbPassword};Trusted_Connection=true;TrustServerCertificate=True";

builder.Services.AddCalifornianHealthContext(applicationConnectionString);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
