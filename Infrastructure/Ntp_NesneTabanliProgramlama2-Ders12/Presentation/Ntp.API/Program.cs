using Ntp.Application;
using Ntp.Application.Exceptions;
using Ntp.Mapper;
using Ntp.Persistance;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);


builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.MapScalarApiReference(options =>
{
    options.Title = "Nesne Programlama Projesi";
    options.Theme = ScalarTheme.Default;

});

app.ConfigureExceptionHandlingMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
