

using Microsoft.EntityFrameworkCore;
using tik_tak_toe_server.Database.Context;
using tik_tak_toe_server.Helpers;

var currentDirectory = Directory.GetCurrentDirectory();

var parentDirectory = Directory.GetParent(currentDirectory)?.FullName;

if(parentDirectory != null)
{
    var envFilePath = Path.Combine(parentDirectory, ".env.development");
    LoadEnv.Execute(envFilePath);
}

var builder = WebApplication.CreateBuilder(args);

builder.Configuration["ConnectionStrings:DefaultConnection"] = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
