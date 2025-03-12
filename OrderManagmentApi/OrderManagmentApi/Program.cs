using System.Text;
using Application.Extentions;
using FluentValidation.AspNetCore;
using Infrastructure.Context;
using Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;
using NLog.Web;
using OrderManagmentApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseNLog();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddScoped<ErrorHandlingMiddleware>();


builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddApplicationLayer();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<SeederRepository>();
    await seeder.SeedData();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthentication();
app.UseHttpsRedirection();
app.MapControllers();


app.Run();
