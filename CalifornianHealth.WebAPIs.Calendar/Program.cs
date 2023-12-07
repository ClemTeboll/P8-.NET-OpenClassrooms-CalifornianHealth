using CalifornianHealth.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);
//var applicationConnectionString = builder.Configuration.GetConnectionString("ApplicationConnection")!;

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("SA_PASSWORD");
var applicationConnectionString = $"Data Source={dbHost};Database={dbName}; User Id=sa; Password={dbPassword};Trusted_Connection=true;TrustServerCertificate=True";

builder.Services.AddScoped(serviceProvider => serviceProvider.GetService<CalifornianHealthContext>()!);

builder.Services.AddControllers();
builder.Services.AddCalifornianHealthContext(applicationConnectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IConsultantRepository>();

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

