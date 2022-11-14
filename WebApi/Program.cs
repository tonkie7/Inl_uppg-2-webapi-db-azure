using Microsoft.EntityFrameworkCore;
using WebApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection (göra den tillgängling) - UseCosmos vill ha in ConnectionString och Dbnamnet
builder.Services.AddDbContext<DataContext>(x => 
    x.UseCosmos(
        builder.Configuration.GetSection("CosmosDB").GetValue<string>("ConnectionString"),
        builder.Configuration.GetSection("CosmosDB").GetValue<string>("DatabaseName")
    ));

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
