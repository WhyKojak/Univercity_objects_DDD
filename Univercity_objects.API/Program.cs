using Microsoft.EntityFrameworkCore;
using Univercity_objects.Infrastructure.Repository;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<Univercity_objects.Infrastructure.BaseContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped<CafedraRepository>();
builder.Services.AddScoped<AuditoryRepository>();
builder.Services.AddScoped<ComputerRepository>();
builder.Services.AddScoped<FurnitureRepository>();
builder.Services.AddScoped<MultimediaEqumentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
