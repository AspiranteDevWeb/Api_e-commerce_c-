//using API.Data;

using API.Errors;
using API.Extensions;
using API.Middleware;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAplicationServices(builder.Configuration);
// Add services to the container.

//para conectar com o sqlserver
/*
 * builder.Services.AddEntityFrameworkSqlServer().AddDbContext<StoreContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbSqlServer")));
 */

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


//app.UseHttpsRedirection();

//app.useStaticFiles(); serve para permitir carregar as fotos na pasta wwwroot para expor na web
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    logger.LogError(ex,"An error occured during migrations");
}


app.Run();
