using CalifornianHealth.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);
var applicationConnectionString = builder.Configuration.GetConnectionString("ApplicationConnection")!;

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

