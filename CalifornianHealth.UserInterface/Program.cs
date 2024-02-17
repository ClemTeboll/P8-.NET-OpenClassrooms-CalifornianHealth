using CalifornianHealth.UserInterface.Services;
using CalifornianHealth.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

//var applicationConnectionString = builder.Configuration.GetConnectionString("ApplicationConnection");

//builder.Services.AddCalifornianHealthContext(applicationConnectionString!);

builder.Services.AddRazorPages();
builder.Services.AddHttpClient<ApiClient>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapGet("/", () =>
{
    return Results.Redirect("Home/Index");
});

app.MapRazorPages();

app.Run();
