using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//builder.Services.AddDbContext<Univercity_objects.Infrastructure.BaseContext>(options =>
 //options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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
