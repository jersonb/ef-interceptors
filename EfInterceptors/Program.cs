using EfInterceptors.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Logging
    .ClearProviders()
    .AddSimpleConsole(x =>
{
    x.TimestampFormat = "[HH:mm:ss] ";
});
var services = builder.Services;
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("EfInterceptorsContext")
    ?? throw new InvalidOperationException("Connection string 'EfInterceptorsContext' not found.");

services.AddDbContext<EfInterceptorsContext>((sp,options) =>
{
    options.UseSqlite(connectionString);
});

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();

var context = scope.ServiceProvider.GetRequiredService<EfInterceptorsContext>();
await context.Database.MigrateAsync();
await app.RunAsync();